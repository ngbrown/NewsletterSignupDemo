namespace Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using Infrastructure.Storage;

    using Model;

    public class SubscriptionController : Controller
    {
        private const int PageSize = 20;
        private readonly IDataStorage dataStorage;

        public SubscriptionController(IDataStorage dataStorage)
        {
            this.dataStorage = dataStorage;
        }

        //
        // GET: /Subscription/

        public ActionResult Index(int? pg)
        {
            int pageIndex = 0;
            if (pg.HasValue)
            {
                pageIndex = pg.Value;
            }

            using (var session = this.dataStorage.NewSession())
            {
                var items = session.All<Subscription>();
                var list = new PagedList<Subscription>(items, pageIndex, PageSize);
                return View(list);
            }
        }

        //
        // GET: /Subscription/Details/john@smith.com

        public ActionResult Details(string email)
        {
            using (var session = this.dataStorage.NewSession())
            {
                var item = session.Single<Subscription>(x=>x.EMail == email);
                return View(item);
            }
        }

        //
        // GET: /Subscription/Create

        //[Authorize(Roles="Administrator")]
        public ActionResult Create()
        {
            var item = new Subscription();
            return View(item);
        } 

        //
        // POST: /Subscription/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles="Administrator")]
        public ActionResult Create(FormCollection collection)
        {
            var item = new Subscription();
            //please don't omit this...
            var whiteList = new string[] { "FirstName", "LastName", "EMail" };
            this.UpdateModel(item, whiteList, collection.ToValueProvider());

            if (ModelState.IsValid)
            {
                try
                {
                    using (var session = this.dataStorage.NewSession())
                    {
                        if (session.Single<Subscription>(x => x.EMail.Equals(item.EMail, StringComparison.InvariantCultureIgnoreCase)) != null)
                        {
                            this.FlashWarning("Subscription already exists for e-mail address");
                            return this.View();
                        }

                        session.Add<Subscription>(item);
                        session.CommitChanges();
                        this.FlashInfo("Subscription saved...");
                        return RedirectToAction("Index", "Home");
                    }
                }
                catch
                {
                    this.FlashError("There was an error adding this subscription");
                    return View();
                }
            }

            return View(item);
        }
        
        //
        // GET: /Subscription/Edit/5
 
        //[Authorize(Roles="Administrator")]
        public ActionResult Edit(string email)
        {
            using (var session = this.dataStorage.NewSession())
            {
                var item = session.Single<Subscription>(x=>x.EMail == email);
                return View(item);
            }
        }

        //
        // POST: /Subscription/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles="Administrator")]
        public ActionResult Edit(string email, FormCollection collection)
        {
            using (var session = this.dataStorage.NewSession())
            {
                var item = session.Single<Subscription>(x=>x.EMail == email);
                //please don't omit this...
                var whiteList = new string[] { "field1", "field2" };
                UpdateModel(item, whiteList, collection.ToValueProvider());

                if (ModelState.IsValid)
                {
                    try
                    {
                        session.Add<Subscription>(item);
                        session.CommitChanges();
                        this.FlashInfo("Subscription saved...");
                        return RedirectToAction("Index");
                    }
                    catch
                    {
                        this.FlashError("There was an error saving this record");
                        return View();
                    }
                }

                return View(item);
            }
        }

        //
        // GET: /Subscription/Delete
        public ActionResult Delete()
        {
            var item = new Subscription();
            return View(item);
        }


        //
        // POST: /Subscription/Delete/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles="Administrator")]
        public ActionResult Delete(string email, FormCollection collection)
        {
            using (var session = this.dataStorage.NewSession())
            {
                var item = session.Single<Subscription>(x=>x.EMail == email);

                try
                {
                    if (item == null)
                    {
                        this.FlashWarning("Subscription does not exist for e-mail address");
                        return this.View();
                    }

                    session.Delete<Subscription>(item);
                    session.CommitChanges();
                    this.FlashInfo("Subscription removed ...");
                    return RedirectToAction("Index", "Home");
                }
                catch
                {
                    this.FlashError("There was an error removing this subscription");
                    return View();
                }
            }
        }
    }
}

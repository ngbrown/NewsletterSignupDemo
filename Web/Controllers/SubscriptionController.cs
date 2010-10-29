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
            var whiteList = new[] { "FirstName", "LastName", "EMail" };
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

                        session.Add(item);
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
        // GET: /Subscription/Delete
        public ActionResult Delete(string email)
        {
            var item = new Subscription
                {
                    EMail = email
                };

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

                    session.Delete(item);
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

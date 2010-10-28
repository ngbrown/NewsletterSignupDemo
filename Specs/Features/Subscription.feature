Feature: Subscription
	In order to get a newsletter about awsome deals
	As a user
	I want to provide my first and last name and e-mail address
	and get a success message if it was the first time.

Scenario: New subscription
	Given a subscription does not exist with an e-mail of "jonny@boy.com" 
	When a user with the name "Smith, John" and e-mail "jonny@boy.com" subscribes
	Then a success message is displayed
	And the e-mail "jonny@boy.com" is not in the persistent store

Scenario: Already existing subscription
	Given a subscription does exist with a name of "Smith, Jonny" and an e-mail of "jonny@boy.com" 
	When a user with the name "Smith, John" and e-mail "jonny@boy.com" subscribes
	Then a error message is displayed
	And the e-mail "jonny@boy.com" is in the persistent store

Scenario: Removing existing subscription
	Given a subscription does exist with a name of "Smith, Jonny" and an e-mail of "jonny@boy.com" 
	When a user with the name "Smith, John" and e-mail "jonny@boy.com" un-subscribes
	Then a success message is displayed
	And the e-mail "jonny@boy.com" is not in the persistent store

Scenario: Attempting to remove non-existing subscription
	Given a subscription does not exist with an e-mail of "jonny@boy.com" 
	When a user with the name "Smith, John" and e-mail "jonny@boy.com" un-subscribes
	Then a error message is displayed
	And the e-mail "jonny@boy.com" is not in the persistent store

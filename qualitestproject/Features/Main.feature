Feature: Main

Scenario: Login to App
	Given I add four random items to my cart
	When  I view my cart
	Then i found four items listed in my cart
	When I search for lowest price item
	Then i am able to remove lowest price item from cart
	Then i am able to verify three items in my cart

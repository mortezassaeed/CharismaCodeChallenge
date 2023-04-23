Feature: Feature1
	In order to purchase a product inside the application
		As a customer
		I want to be able to create a shopping cart and add items.

Scenario: Defining more than one base unit of measure for a dimension
	Given I have already logged in as customer
	When I add cart with following items
	| item1 | item2 |
	| 1     | 2     |
	Then I could see my cart in my profile
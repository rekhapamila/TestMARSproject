Feature: SkillsWap
	The file contains features of skills wap application

Scenario: Check if user could able to add a language 
	Given I clicked on the Language tab under Profile page
	When I add a new language
	Then that language should be displayed on my listings

Scenario: Check if user could able to add a skill 
	Given I clicked on the Skill tab under Profile page
	When I add a new Skill
	Then that Skill should be displayed on my listings

Scenario: Check if user could able to add a new category
	Given I clicked on the manage listing tab
	When I click on edit on a category
	And i fill in all the mandatory fields
	Then the new category is displayed in the manage listing page
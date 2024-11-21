Feature: Language

As a user I would be able to show what languages I know.
So that the people seeking for languages can look at what details I hold.

@addnewlanguages
Scenario Outline: 1.Add valid language to user profile 
	Given I logged into Mars portal successfully
	When  I navigate to the Profile page
	When  I added a new language with '<Language>','<LanguageLevel>'
	Then  the Language should be added successfully with new '<Language>','<LanguageLevel>'
	
	Examples: 
	| Language | LanguageLevel    |
	| English  | Basic            |
	| Chineese | Conversational   |
	

@editlanguages
Scenario Outline:2.Edit the newly added languages
		Given I logged into Mars portal successfully
		When  I navigate to the Profile page
		When  I added a new language with '<Language>','<LanguageLevel>'
		When  I updated language with '<EditedLanguage>','<EditedLanguageLevel>'
		Then the Language should be updated successfully with new '<EditedLanguage>','<EditedLanguageLevel>'

		Examples: 
		 | Language | LanguageLevel | EditedLanguage | EditedLanguageLevel |
		 | Tamil    | Basic         | Malayalam      | Fluent              |


@deletelanguage	
Scenario Outline: 3.Delete the newly added language
		Given I logged into Mars portal successfully
		When I navigate to the Profile page
		When  I added a new language with '<Language>','<LanguageLevel>'
		When I deleted newly added language
		Then language with name '<Languagetobedeleted>' should be deleted successfully 

		Examples: 
		| Language | LanguageLevel | Languagetobedeleted |
		|   Urdu   |   Fluent      |    Urdu             |


@addlanguagewithoutlanguageandlevel
Scenario Outline:4. Add languages without language and level
		Given I logged into Mars portal successfully
		When I navigate to the Profile page
		When I added new language with blank '<Language>' and '<LanguageLevel>'
		Then language is not added to the profile

		Examples: 
		| Language | LanguageLevel |
		|          |               |


@addalreadyexistinglanguage
Scenario Outline: 5.Add language with same language and language level
		Given I logged into Mars portal successfully
		When I navigate to the Profile page
		When I added language with already existing '<Language>' and '<LanguageLevel>'
		Then Language should not be added to the profile

		Examples: 
		| Language | LanguageLevel |
		| English  | Basic         |


@addlanguagewithoutlanguage
Scenario Outline:6.Add languages without language
		Given I logged into Mars portal successfully
		When I navigate to the Profile page
		When I add language with blank '<Language>' and '<LanguageLevel>'
		Then Language with blank '<Language>' is not added to profile

		Examples: 
		| Language | LanguageLevel |
		|          | Fluent        |
		

@addlanguagewithoutlanguagelevel
Scenario Outline:7.Add languages without language level
		Given I logged into Mars portal successfully
		When I navigate to the Profile page
		When I add language with '<Language>' and blank '<LanguageLevel>'
		Then Language with blank '<LanguageLevel>' is not added to profile

		Examples: 
		| Language | LanguageLevel |
		| Tamil    |			   |


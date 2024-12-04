Feature: Skill

As a user I would be able to show what skills I know.
So that the people seeking for skills can look at what details I hold.

@addnewskill
Scenario Outline: 1.Add valid skill to user profile 
	Given I logged into Mars portal successfully
	When  I navigate to the Skills page
	When  I added a new skill with '<Skill>','<SkillLevel>'
	Then  the skill should be added successfully with new '<Skill>' 

	Examples: 
	| Skill | SkillLevel   |
	| Java  | Expert       |
	| C#    | Beginner     |
	| C++   | Intermediate |


@editskill
Scenario Outline:2.Edit the newly added skill
		Given I logged into Mars portal successfully
		When  I navigate to the Profile page
		When  I updated skill with '<Skill>' and '<SkillLevel>' as '<EditedSkill>','<EditedSkillLevel>'
		Then the skill should be updated successfully with new '<EditedSkill>','<EditedSkillLevel>'

		Examples: 
		 | Skill | SkillLevel | EditedSkill     | EditedSkillLevel |
		 | Git   | Beginner   | Test Automation | Expert           |


@deleteskill		
Scenario Outline: 3.Delete the newly added skill
		Given I logged into Mars portal successfully
		When  I navigate to the Profile page
		When I added new skill with '<NewSkill>','<NewSkillLevel>'
		When  I deleted newly added skill with '<Skill>' and '<SkillLevel>'
		Then  skill with name '<SkillToBeDeleted>' should be deleted successfully 

		Examples: 
		| Skill      | SkillLevel | SkillToBeDeleted | NewSkill        | NewSkillLevel |
		| TeamPlayer | Expert     | TeamPlayer       | Time Management | Expert        |


@addskillwithoutskillandexperience
Scenario Outline:4.Add skill without skill and experience level
		Given I logged into Mars portal successfully
		When I navigate to the Profile page
		When I added new skill with blank '<Skill>' and blank '<SkillLevel>'
		Then skill with blank '<Skill>' and blank '<SkillLevel>' is not added to the profile

		Examples: 
		| Skill | SkillLevel |
		|       |            |

@addalreadyexistingskill
Scenario Outline:5.Add skill with already existing skill and skilllevel
	Given I logged into Mars portal successfully
	When I navigate to the Profile page
	When I added an already existing skill with '<Skill>' and '<SkillLevel>'
	Then already existing skill is not added to the profile

	Examples: 
	| Skill | SkillLevel |
	| Java  | Expert     |

@addskillwithoutskill
Scenario Outline:6.Add skill without skill
		Given I logged into Mars portal successfully
		When I navigate to the Profile page
		When I add skill with blank '<Skill>' and '<SkillLevel>'
		Then skill with blank '<Skill>' is not added to profile

		Examples: 
		| Skill | SkillLevel |
		|       | Expert     |

@addskillwithoutskilllevel
Scenario Outline:7.Add skill without skill level
		Given I logged into Mars portal successfully
		When I navigate to the Profile page
		When I add skill with '<Skill>' and blank '<SkillLevel>'
		Then skill with blank '<SkillLevel>' is not added to the profile

		Examples: 
		| Skill				 | SkillLevel |
		| Time Management    |			  |


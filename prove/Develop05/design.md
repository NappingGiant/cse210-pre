
# Specification
Write an Eternal Quest program to track various kinds of goals.

Your program can include whatever kinds of "gamification" components you like, but each program should have the following base functionality.

# Functional requirements
Your program must do the following:

1. Provide for simple goals that can be marked complete and the user gains some value.
        For example, if you run a marathon you get 1000 points.
2. Provide for eternal goals that are never complete, but each time the user records them, they gain some value.
        For example, every time you read your scriptures you get 100 points.
3. Provide for a checklist goal that must be accomplished a certain number of times to be complete. Each time the user records this goal they gain some value, but when they achieve the desired amount, they get an extra bonus.
        For example, if you set a goal to attend the temple 10 times, you might get 50 points each time you go, and then a bonus of 500 points on the 10th time.
4. Display the user's score.
5. Allow the user to create new goals of any type.
6. Allow the user to record an event (meaning they have accomplished a goal and should receive points).
7. Show a list of the goals. This list should show indicate whether the goal has been completed or not (for example [ ] compared to [X]), and for checklist goals it should show how many times the goal has been completed (for example Completed 2/5 times).
8. Allow the user's goals and their current score to be saved and loaded.

# Design Requirements
    In addition your program must:

1. Use inheritance by having a separate class for each kind of activity with a base class to contain any shared attributes or behaviors.
2. Use polymorphism by having derived classes override base class methods where appropriate.
3. Follow the principles of encapsulation and abstraction by having private member variables and putting related items in the same class.

________________
abstract Goal
_name: string
_descripting: string
_pointsAccomplished: int (cumulative for this Goal)
_eventPoints: int (for each occurence)
_expectedEvents: int (0=Eternal, 1=simple, >1=Checklist)
_completedEvents: int
_bonusPoints: int (for Checklist, but could apply to others for other reasons)
_completed: bool

----------------
GetAccomplishedPoints: int
SetAccomplishedPoints: abstract?
GetExpectedEvents: int
SetExpectedEvents: abstract?
GetCompletedEvents: int
SetCompletedEvents: abstract?
GetEventPoints: int
SetEventPoints: void or abstract?
GetBonusPoints: int
SetBonusPoints: abstract?
GetCompletedStatus: bool
GetPrintString(): abstract
SetCompletedStatus: abstract

________________

________________
SimpleGoal: Goal

----------------
SetAccomplishedPoints: void
SetExpectedEvents: void?
SetCompletedEvents: void?
SetOccurencePoints: void?
SetExpectedEvents: void?
SetBonusPoints: void?
SetCompletedStatus: void
GetPrintString(): string

________________

________________
EternalGoal: Goal

----------------
SetAccomplishedPoints: void
SetExpectedEvents: void?
SetCompletedEvents: void?
SetOccurencePoints: void?
SetExpectedEvents: void?
SetBonusPoints: void?
SetCompletedStatus: void
GetPrintString(): string

________________

________________
ChecklistGoal: Goal

----------------
SetAccomplishedPoints: void
SetExpectedEvents: void?
SetCompletedEvents: void?
SetOccurencePoints: void?
SetExpectedEvents: void?
SetBonusPoints: void?
SetCompletedStatus: void
GetPrintString(): string

________________

________________
EternalQuest
_sg: SimpleGoal
_eg: EternalGoal
_cg: ChecklistGoal
_totalPoints: int
----------------
Menu(): void
CalculateTotalPoints(): int
________________

________________
StoreGoals

----------------
SaveGoalList(List<Goals>):void
LoadGoalList():  List<Goals>
GetFileName(): string
________________

________________
----------------
________________

________________
----------------
________________
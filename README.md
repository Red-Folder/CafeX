# Summary
This sample code is provided to demonstrate TDD thinking for a simple set of code.

The requirements for this code was:

### Step 1 : Standard Bill
Pass in a list of purchased items that produces a total bill.
e.g. [“Cola”, “Coffee”, “Cheese Sandwich”] returns 3.5

### Step 2: Service Charge
Add support for a service charge :

* When all purchased items are drinks no service charge is applied
* When purchased items include any food apply a service charge of 10% to the total bill
(rounded to 2 decimal places)
 * When purchased items include any hot food apply a service charge of 20% to the total bill
with a maximum £20 service charge

## Tools used
Sample has been produced with:

* .Net Core
* dotnet cli
* Visual Studio code
* xUnit - a .net testing framework
* moq - a .net Mocking framework

## Development approach
This was done with an attempt to follow TDD rules.

As much as possible I tried to create a commit between most TDD actions (create test, commit, create implementation, commitm repeat).

I've attempting to keep the code to the requirements without building too much (YAGNI).

I set myself a timelimit (40 minutes) - which I went over a bit, so curtailed the refactoring once the requirements where met.

## Further work
I suspect I'll update this section in morning when I've thought about it, but here are the further actions I'd have looked at if not keeping to the time limit:

* Menu should probably be seperated out as its own object.  Current implementation is very fragile for testing.  One price change and boom
* Ideally use a proper DI container rather than Constructor Injection (clearer to reason).  Note I added the implementation test last to use the Item & Surcharge calculator - this would have been easy to miss if just focusing the unit testing
* I would normally seperate integration tests from unit tests (note that Returns_Correct_Value_Implementation should have been called Returns_Correct_Value_Integration)
* SurchargeCalculator.Calculate should be refactored.  Probably create the rules based on Chain of Responsibility pattern

## Feedback
I always appreciate feedback ... so any comments greatly received.


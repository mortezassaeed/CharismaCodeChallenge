using System;
using TechTalk.SpecFlow;

namespace Charisma.Order.Spec.Tests
{
    [Binding]
    public class Feature1StepDefinitions
    {
        [Given(@"I have already logged in as customer")]
        public void GivenIHaveAlreadyLoggedInAsCustomer()
        {
            throw new PendingStepException();
        }

        [When(@"I add cart with following items")]
        public void WhenIAddCartWithFollowingItems(Table table)
        {
            throw new PendingStepException();
        }

        [Then(@"I could see my cart in my profile")]
        public void ThenICouldSeeMyCartInMyProfile()
        {
            throw new PendingStepException();
        }
    }
}

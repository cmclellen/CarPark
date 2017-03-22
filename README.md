# CarPark 
###### By Craig McLellen

Please see the UICoordinatorTests class (int the CarPark.UnitTests project) for examples of input. Note that this class is more of an integration test than a unit test (usually I would put this in it's own integration tests project), whereas all other tests are pure unit tests.

## Assumptions
1. A calendar day is from Midnight to the following midnight (24 hours).
2. For all time ranges, the start time is inclusive while the end time is exclusive, e.g. 
    1. for the Standard rate, if the patron parks their car for 1 hour, they'll be charged $10.00, but if parked for 2 hours, will be charged $15.00.
    2. for the Early Bird rate, if the patron enters at 6AM, they're eligible for this rate provided the leave at the correct times, but if they enter at 9AM, they're not.
3. The application is run on a machine where the regional settings are configured to Australia.
4. All prices are $AUD.

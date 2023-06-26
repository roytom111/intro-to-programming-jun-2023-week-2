# Business Clock API

## Status

```http
GET /status
```

Examples:

If we are open:

```json
{
    "open": "true"
}
```

If we are closed:

```json
{
    "open": "false",
    "opensAt": "--date and time we are open next"
}
```

### Business Rules

We are open from 9:00 AM until 5:00 PM Monday-Friday.
What timezone? - Eastern Time - (current eastern time)
We are closed on the weekends.

> What questions would you ask about this?
> What *examples* would you use to test it?

## GIVEN / WHEN / THEN

```
GIVEN a client makes a request to the API
    AND it is during business hours
WHEN they do a GET request to the /status resource
THEN They should be told we are open
```

"Given" is the "context" for what is happening.
"When" is the activity the drives the operation.
"Then" is the observable (testable) outcome.


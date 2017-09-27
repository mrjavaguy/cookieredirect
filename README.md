# cookieredirect
Repro for Cookie Redirect Issues with ASP.NET Core 2.0

## Sample Fiddler Traces in the file 3746_Full.txt

## Repro Steps

1. Start this application
1. Start fiddler
1. Post to the url http://localhost:38370/auth/login using fiddler or postman (body needs to contain jwt=something)
1. In fidder observe the redirect as happened
1. Observe that the cookie is set on the response in the redirect
1. Observe that the cookie is not attached to the call made after the redirect
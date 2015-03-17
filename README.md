# winforms-mvp-example
Automatically exported from code.google.com/p/winforms-mvp-example

I have been trying to work out how to implement MVP (Model-View-Presenter) in winforms for a while now, but most of the examples are too simplistic - they don't deal with multiple forms, modal forms, and other tricky things.

This project is my attempt at creating a (very slightly) more complex MVP example, with the main goal being testability of the presentation code.

There are a couple of patterns and technologies used here - data is stored in a SQL CE database and loaded using NHibernate. The views are largely based on the 'Passive View' style of MVP, although I'm intending to provide two versions - one Passive View, one Supervising Controller (which uses data binding).

In terms of communication between the view and the presenter, I've used the two different ways - the view firing events, and the view calling the presenter. I think I prefer the view calling the presenter, even though it increases coupling, but I put both in as an example (or maybe just to confuse you, you'll never know!).

I've also got the presenter creating the view as opposed to the other way round, which I think makes more sense logically - although some people prefer a view-first approach.

I've just used a very simple 'Service Locator' instead of using an IOC container, as I think it's simpler this way and it wasn't worth it on a project of this size anyway. I've included NUnit tests (both unit and integration tests), but I haven't used an isolation/mocking framework - it probably would have been a bit easier as it turns out, but again it muddies the water a bit. I've also used NUnitForms to test the views - although as we're using MVP, these tests basically just ensure the views fire the right events/call the right presenter methods.

So there you are, if you want to have a look at the source code and point out the many thing I've done wrong, I'll try and improve it. But don't be too harsh, as this is the first time I've tried several of these things out (MVP, NHibernate, 'DDD' style architecture, some of the TDD elements).

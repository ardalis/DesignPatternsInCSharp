# Discount Rules with Short-Circuiting

In response to a reader question found here:

https://github.com/ardalis/DesignPatternsInCSharp/issues/15

This folder shows how to add a new ReferralDiscount that yields a 30% discount and immediately stops checking all other rules. There are two parts to this:

- This rule needs to run first
- If it matches, no other rules should run

Our design will allow for multiple short-circuiting rules which can be run in a priority order.

# Complex unit test tasks

[![Unit Tests](https://github.com/algorythm/ContextUnitTests/workflows/Unit%20Tests/badge.svg)](https://github.com/algorythm/ContextUnitTests/actions)

... or at least I think it's a quite difficult problem to solve (hence why I haven't solved it yet)

## Rules

The rules are simple:

1. Make sure all unit tests runs
2. You cannot modify any files under `BusinessLogic/`

## The Problem

In `BusinessLogic/UserService` there is a method called `GetOrCreateUser`. It creates a user if it doesn't exist and returns the user. If the user exists, it just returns that user right away.

The goal is to test if the service tries to save the user, even though it already exists. Or in other words, make sure `GetOrCreate_DoesNotCreateUser_WhenUserExists` succeeds.

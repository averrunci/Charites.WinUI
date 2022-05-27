// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Carna;

namespace Charites.Windows.Samples.SimpleLoginDemo.Presentation.Login;

[Specification("LoginContent Spec")]
class LoginContentSpec : FixtureSteppable
{
    LoginContent LoginContent { get; } = new()
    {
        UserId = { Value = "Initial User Id" },
        Password = { Value = "Initial Password" }
    };

    [Example("Validates the user id and the password")]
    [Sample("", "", false, Description = "When the user id is empty and the password is an empty")]
    [Sample("", "password", false, Description = "When the user id is am empty and the password is not an empty")]
    [Sample("user", "", false, Description = "When the user id is not an empty and the password is empty")]
    [Sample("user", "password", true, Description = "When the user id is not null or empty and the password is not an empty")]
    void Ex01(string userId, string password, bool expected)
    {
        When("the user id is set", () => LoginContent.UserId.Value = userId);
        When("the password is set", () => LoginContent.Password.Value = password);
        Then($"the result should be {expected}", () => LoginContent.IsValid.Value == expected);
    }
}
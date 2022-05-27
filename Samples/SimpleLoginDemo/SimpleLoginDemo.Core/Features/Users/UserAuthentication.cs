// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
namespace SimpleLoginDemo.Core.Features.Users;

public class UserAuthentication : IUserAuthentication
{
    public UserAuthenticationResult Authenticate(User user)
        => user.UserId == user.Password ? UserAuthenticationResult.Success : UserAuthenticationResult.Failure;
}
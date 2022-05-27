// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Charites.Windows.Samples.SimpleLoginDemo.Presentation.Login;
using SimpleLoginDemo.Core.Features.Users;

namespace Charites.Windows.Samples.SimpleLoginDemo.Adapter.Mappers;

internal static class UserAuthenticationResultMapper
{
    public static LoginAuthenticationResult ToLoginAuthenticationResult(this UserAuthenticationResult @this)
        => @this switch
        {
            UserAuthenticationResult.Success => LoginAuthenticationResult.Success,
            UserAuthenticationResult.Failure => LoginAuthenticationResult.Failure,
            _ => throw new InvalidOperationException()
        };
}
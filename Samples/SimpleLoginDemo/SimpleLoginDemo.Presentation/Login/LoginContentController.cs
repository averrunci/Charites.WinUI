// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Charites.Windows.Mvc;
using Charites.Windows.Samples.SimpleLoginDemo.Presentation.Home;

namespace Charites.Windows.Samples.SimpleLoginDemo.Presentation.Login;

[View(Key = nameof(LoginContent))]
public  class LoginContentController
{
    private void SetDataContext(LoginContent? content) => this.content = content;
    private LoginContent? content;

    private async Task LoginButton_Click([FromDI] ILoginCommand command, [FromDI] IContentNavigator navigator)
    {
        if (content is null) return;

        content.Message.Value = string.Empty;

        if (!content.IsValid.Value) return;

        switch (await command.AuthenticateAsync(content))
        {
            case LoginAuthenticationResult.Success:
                navigator.NavigateTo(new HomeContent(content.UserId.Value));
                break;
            case LoginAuthenticationResult.Failure:
                content.Message.Value = Resources.LoginFailure;
                break;
        }
    }
}
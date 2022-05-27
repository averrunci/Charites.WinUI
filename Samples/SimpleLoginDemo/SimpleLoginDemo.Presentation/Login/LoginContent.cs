// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using System.ComponentModel.DataAnnotations;
using Charites.Windows.Mvc.Bindings;

namespace Charites.Windows.Samples.SimpleLoginDemo.Presentation.Login;

public class LoginContent
{
    [Display(Name = "User ID")]
    [Required]
    public ObservableProperty<string> UserId { get; } = string.Empty.ToObservableProperty();

    [Display(Name = "Password")]
    [Required]
    public ObservableProperty<string> Password { get; } = string.Empty.ToObservableProperty();

    public ObservableProperty<string> Message { get; } = string.Empty.ToObservableProperty();

    public ObservableProperty<bool> IsValid { get; } = false.ToObservableProperty();

    public LoginContent()
    {
        UserId.EnableValidation(() => UserId);
        Password.EnableValidation(() => Password);

        UserId.PropertyValueChanged += OnUserIdChanged;
        Password.PropertyValueChanged += OnPasswordChanged;
    }

    private void Validate()
    {
        IsValid.Value = !UserId.HasErrors && !Password.HasErrors;
    }

    private void OnUserIdChanged(object? sender, PropertyValueChangedEventArgs<string> e)
    {
        UserId.EnsureValidation();
        Validate();
    }

    private void OnPasswordChanged(object? sender, PropertyValueChangedEventArgs<string> e)
    {
        Password.EnsureValidation();
        Validate();
    }
}
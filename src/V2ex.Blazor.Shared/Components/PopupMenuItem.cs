namespace V2ex.Blazor.Components;

public record PopupMenuItem(string Text, Func<Task> InvokeAsync);
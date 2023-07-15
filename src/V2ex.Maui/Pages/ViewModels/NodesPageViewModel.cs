﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using V2ex.Api;
using Volo.Abp.DependencyInjection;

namespace V2ex.Maui.Pages.ViewModels;

public partial class NodesPageViewModel : ObservableObject, IQueryAttributable, ITransientDependency
{
    [ObservableProperty]
    private string? _currentState;
    [ObservableProperty]
    private Exception? _exception;
    [ObservableProperty]
    private bool _canCurrentStateChange = true;

    [ObservableProperty]
    private NodesViewModel? _nodes;

    public NodesPageViewModel(ApiService apiService)
    {
        this.ApiService = apiService;
        
    }

    private ApiService ApiService { get; }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
    }

    [RelayCommand(CanExecute = nameof(CanCurrentStateChange))]
    public async Task Load(CancellationToken cancellationToken = default)
    {
        try
        {
            this.CurrentState = StateKeys.Loading;
            var nodes = await this.ApiService.GetNodesInfo();
            this.Nodes = new NodesViewModel(nodes);
            this.CurrentState = StateKeys.Success;
        }
        catch (Exception exception)
        {
            this.Exception = exception;
            this.CurrentState = StateKeys.Error;
        }
    }
}

public class NodesViewModel : ObservableObject
{
    public NodesViewModel(NodesInfo nodesInfo)
    {

    }

}
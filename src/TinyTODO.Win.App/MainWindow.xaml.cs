﻿using NHotkey.Wpf;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TinyTODO.Core;
using TinyTODO.Core.Contracts;
using TinyTODO.Core.DataModel;
using TinyTODO.Core.Windows;

namespace TinyTODO.App.Windows;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private IConfirmationEmitter _confirmationEmitter = new ConsoleBeepEmitter();
    private ClipboardDataProvider _clipboardProvider = new ClipboardDataProvider();
    private IToDoItemStorage _storage = new ToDoItemStorage();
    private IToDoItemPresenter _presenter = new TempPresenter();

    public MainWindow()
    {
        InitializeComponent();

        HotkeyManager.Current.AddOrReplace(HotkeyIdentifiers.StoreClipboardContent, Key.C, ModifierKeys.Shift | ModifierKeys.Alt, (sender, args) => OnHotkey(sender, args));
    }

    public void OnHotkey(object? sender, object args)
    {
        ClipboardData? data = _clipboardProvider.GetData();
        ToDoContext? context = ContextProvider.GetToDoContext();
        if (data == null)
        {
            _confirmationEmitter.NoData();
            return;
        }

        ToDoItem? todoItem = new ToDoItem(data, context);
        _storage.PersistAsync(todoItem);
        _presenter.Present(todoItem);

        _confirmationEmitter.Done();
    }
}

﻿namespace Riter.ViewModel;

public class SettingPanelViewModel : BaseViewModel
{
    private readonly ISettingPanelStateHandler _settingPanelStateHandler;

    public SettingPanelViewModel(ISettingPanelStateHandler settingPanelStateHandler)
    {
        _settingPanelStateHandler = settingPanelStateHandler;
        _settingPanelStateHandler.PropertyChanged += OnStateChanged;
    }

    public string PinPanel => _settingPanelStateHandler.PinPanel;

    public bool SettingButtonClicked => _settingPanelStateHandler.SettingButtonClicked;

    public string LatestVersion => _settingPanelStateHandler.LatestVersion;

    public Visibility SettingPanelVisibility => GetVisibility(_settingPanelStateHandler.SettingPanelVisibility);

    public Visibility BrushPanelVisibility => GetVisibility(_settingPanelStateHandler.BrushPanelVisibility);

    public Visibility ColorPanelVisibility => GetVisibility(_settingPanelStateHandler.ColorPanelVisibility);

    public Visibility ShapePanelVisibility => GetVisibility(_settingPanelStateHandler.ShapePanelVisibility);

    public Visibility TimerPanelVisibility => GetVisibility(_settingPanelStateHandler.TimerPanelVisibility);

    public Visibility NotificationIndicatorVisibility => GetVisibility(_settingPanelStateHandler.NotificationIndicatorVisibility);

    public ICommand ToggleSettingsPanelCommand => new RelayCommand(_settingPanelStateHandler.ToggleSettingsPanel);

    public ICommand ShowBrushSettingsPanelCommand => new RelayCommand<string>(_settingPanelStateHandler.ToggleBrushSettingsPanel);

    public ICommand ShowShapePanelCommand => new RelayCommand<string>(_settingPanelStateHandler.ToggleShapePanel);

    public ICommand ShowTimerPanelCommand => new RelayCommand<string>(_settingPanelStateHandler.ToggleTimerPanel);

    public ICommand ShowColorPanelCommand => new RelayCommand(_settingPanelStateHandler.ToggleColorPanel);

    public ICommand SetPinCommand => new RelayCommand<string>(_settingPanelStateHandler.TogglePinPanel);

    private static Visibility GetVisibility(bool isVisible)
        => isVisible ? Visibility.Visible : Visibility.Hidden;
}

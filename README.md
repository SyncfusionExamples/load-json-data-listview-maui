# How to load the json data in .NET MAUI ListView (SfListView)?

This demo explains about how to load the json data in .NET MAUI ListView (SfListView)?


## Sample

```xaml
<ContentPage.Resources>
    <local:DynamicToPathValueConverter x:Key="converter" />
</ContentPage.Resources>
   
<syncfusion:SfListView
    x:Name="listView"
    Grid.Row="1"
    BackgroundColor="AliceBlue"
    ItemSize="70"
    ItemSpacing="5"
    ItemsSource="{Binding ItemsSource}">
    <syncfusion:SfListView.ItemTemplate>
        <DataTemplate>
            <ViewCell>
                <Grid>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="*" />
                        <ColumnDefinition Width="*" />
                    </Grid.ColumnDefinitions>
                    <Grid.RowDefinitions>
                        <RowDefinition Height="Auto" />
                    </Grid.RowDefinitions>
                    <Label
                        Grid.Column="0"
                        FontAttributes="Bold"
                        FontSize="16"
                        HorizontalOptions="Start"
                        Text="{Binding Converter={StaticResource converter}, ConverterParameter=Value1}"
                        TextColor="Black" />
                    <Label
                        Grid.Column="1"
                        FontAttributes="Bold"
                        FontSize="16"
                        HorizontalOptions="Start"
                        Text="{Binding Converter={StaticResource converter}, ConverterParameter=Value2}"
                        TextColor="Black" />
                </Grid>
            </ViewCell>
        </DataTemplate>
    </syncfusion:SfListView.ItemTemplate>
</syncfusion:SfListView>
```

```c#
public class DynamicToPathValueConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value == null)
            return value;
        ExpandoObject busniessObject = JsonConvert.DeserializeObject<ExpandoObject>(value.ToString());
        var jsonList = busniessObject.ToList();
        if (parameter.Equals("Value1"))
            return jsonList[0].Value;
        if (parameter.Equals("Value2"))
            return jsonList[1].Value;
        return value;
    }
}
```

## Requirements to run the demo

* [Visual Studio 2017](https://visualstudio.microsoft.com/downloads/) or [Visual Studio for Mac](https://visualstudio.microsoft.com/vs/mac/)
* Xamarin add-ons for Visual Studio (available via the Visual Studio installer).

## Troubleshooting

### Path too long exception

If you are facing path too long exception when building this example project, close Visual Studio and rename the repository to short and build the project.

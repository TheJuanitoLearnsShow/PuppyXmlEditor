using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Syncfusion.Maui.DataForm;

namespace PuppyXmlEditor.UI;

public class XmlModelFields  : Collection<DataFormViewItem>, INotifyCollectionChanged, INotifyPropertyChanged, IDataErrorInfo
{
    private ObservableCollection<DataFormViewItem> _items;

    public void Init(Dictionary<string, object> dictionary)
    {
        _items = new ObservableCollection<DataFormViewItem>();
        foreach (var key in dictionary.Keys)
        {
            DataFormItem dataFormItem = null;
            if (key == "Name")
            {
                dataFormItem = new DataFormTextItem()
                {
                    FieldName = key
                };
            }
            else if (key == "Check")
            {
                dataFormItem = new DataFormCheckBoxItem()
                {
                    FieldName = key,
                };

            }
            else if (key == "Switch")
            {
                dataFormItem = new DataFormSwitchItem()
                {
                    FieldName = key,
                };

            }
            else if (key == "Password")
            {
                dataFormItem = new DataFormPasswordItem()
                {
                    FieldName = key,
                };
            }
            else if (key == "Address")
            {
                dataFormItem = new DataFormMultilineItem()
                {
                    FieldName = key,
                };
            }
            else if (key == "DoB")
            {
                dataFormItem = new DataFormDateItem()
                {
                    FieldName = key,
                };
            }
            else if (key == "Time")
            {
                dataFormItem = new DataFormTimeItem()
                {
                    FieldName = key,
                };
            }
            else if (key == "Picker")
            {
                dataFormItem = new DataFormPickerItem()
                {
                    FieldName = key,
                    ItemsSource = new List<string> { "one", "two", "three" },
                };
            }
            else if (key == "ComboBox")
            {
                dataFormItem = new DataFormComboBoxItem()
                {
                    FieldName = key,
                    ItemsSource = new List<string> { "one", "two", "three" },
                };
            }
            else if (key == "AutoComplete")
            {
                dataFormItem = new DataFormAutoCompleteItem()
                {
                    FieldName = key,
                    ItemsSource = new List<string> { "one", "two", "three" },
                };
            }
            else if (key == "RadioGroup")
            {
                dataFormItem = new DataFormRadioGroupItem()
                {
                    FieldName = key,
                    ItemsSource = new List<string> { "one", "two", "three" },
                };
            }

            if (dataFormItem != null)
            {
                _items.Add(dataFormItem);
            }
        }
    }
    
    [Display(AutoGenerateField = false)]
    public string Error
    {
        get
        {
            return string.Empty;
        }
    }

    [Display(AutoGenerateField = false)]
    public string this[string columnName]
    {
        get { return "hello error"; }
        set
        {
            var newvalue = value;

        }
    }

    public event NotifyCollectionChangedEventHandler CollectionChanged
    {
        add => _items.CollectionChanged += value;
        remove => _items.CollectionChanged -= value;
    }

    public event PropertyChangedEventHandler PropertyChanged
    {
        add => ((INotifyPropertyChanged)_items).PropertyChanged += value;
        remove => ((INotifyPropertyChanged)_items).PropertyChanged -= value;
    }
}
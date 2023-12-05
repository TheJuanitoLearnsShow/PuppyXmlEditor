using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;
using Syncfusion.Maui.DataForm;

namespace PuppyXmlEditor.UI;

public partial class MainPage : ContentPage
{
    int count = 0;
    private DataFormItemManagerExt _itemsManager;

    public MainPage()
    {
        this.ContactsInfo = new ContactsInfo();
        InitializeComponent();
        // this.FormEditor.DataObject = this.ContactsInfo;
        SetupForm(this.FormEditor);
        // FormEditor.
    }

    public ContactsInfo ContactsInfo { get; set; }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        count++;

        if (count == 1)
            CounterBtn.Text = $"Clicked {count} time";
        else
            CounterBtn.Text = $"Clicked {count} times";

        SemanticScreenReader.Announce(CounterBtn.Text);
    }
    
    protected  void SetupForm(SfDataForm dataForm)
        {
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            dictionary.Add("Name", "John");
            dictionary.Add("Password", "1234");
            dictionary.Add("Check", true);
            dictionary.Add("Switch", true);
            dictionary.Add("DoB", DateTime.Now.Date);
            dictionary.Add("Time", DateTime.Now);
            dictionary.Add("Address", "");
            dictionary.Add("Picker", "one");
            dictionary.Add("ComboBox", "two");
            dictionary.Add("AutoComplete", "three");
            dictionary.Add("RadioGroup", "one");

            var items = new XmlModelFields();
            items.Init(dictionary);

            dataForm.DataObject = items;
            dataForm.AutoGenerateItems = false;
            
            _itemsManager = new DataFormItemManagerExt(dictionary);
            dataForm.ItemManager = _itemsManager;
            
        }
}
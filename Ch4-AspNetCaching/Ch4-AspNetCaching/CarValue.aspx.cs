using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace Ch4_AspNetCaching {
  public partial class CarValue : System.Web.UI.Page {
    protected override void OnPreRender(EventArgs e) {
      DisplayCache();
    }

    private void DisplayCache() {
      cachedItemsList.Items.Clear();
      
      foreach (DictionaryEntry cachedItem in Cache) {
        var cacheRecord = cachedItem.Key + " - " + cachedItem.Value;
        cachedItemsList.Items.Add(new ListItem(cacheRecord));
      }
      
      if (cachedItemsList.Items.Count == 1) {
        cachedItemsList.Items.Clear();
        cachedItemsList.Items.Add(new ListItem("None"));
      }
    }

    protected void Page_Load(object sender, EventArgs e) {
      getValueButton.Click += new EventHandler(getValueButton_Click);

      if (!IsPostBack) {
        PopulateDropDowns();
      }

    }

    void getValueButton_Click(object sender, EventArgs e) {
      var makeId = int.Parse(makeDropDown.SelectedValue);
      var conditionId = int.Parse(conditionDropDown.SelectedValue);
      var year = int.Parse(yearDropDown.SelectedValue);

      var carValueService = new CarValueService();

      var carValue = carValueService.GetValue(new CarValueArgs { MakeId = makeId, ConditionId = conditionId, Year = year });

      valueLiteral.Text = carValue.ToString("c");

    }

    private void PopulateDropDowns() {
      makeDropDown.Items.AddRange(new[] {
        new ListItem("Honda", "0"),
        new ListItem("Toyota", "1"),
        new ListItem("Ford", "2")
      });

      yearDropDown.Items.AddRange(new[] {
        new ListItem("2010"),
        new ListItem("2011"),
        new ListItem("2012")
      });

      conditionDropDown.Items.AddRange(new[] {
        new ListItem("Poor", "0"),
        new ListItem("Average", "1"),
        new ListItem("Mint", "2")

      });
    }
  }
}
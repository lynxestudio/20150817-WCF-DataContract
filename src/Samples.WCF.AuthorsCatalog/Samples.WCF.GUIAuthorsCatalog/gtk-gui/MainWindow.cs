
// This file has been generated by the GUI designer. Do not modify.

public partial class MainWindow
{
	private global::Gtk.VBox vbox1;
	
	private global::Gtk.Table table1;
	
	private global::Gtk.Calendar calBirthdate;
	
	private global::Gtk.CheckButton chkGender;
	
	private global::Gtk.Label label1;
	
	private global::Gtk.Label label2;
	
	private global::Gtk.Label label3;
	
	private global::Gtk.Label label6;
	
	private global::Gtk.Entry txtFirstName;
	
	private global::Gtk.Entry txtLastName;
	
	private global::Gtk.HBox hbox1;
	
	private global::Gtk.Button btnCreate;
	
	private global::Gtk.Label lbCstatus;
	
	private global::Gtk.ScrolledWindow GtkScrolledWindow;
	
	private global::Gtk.TreeView gridAuthors;
	
	private global::Gtk.HBox hbox2;
	
	private global::Gtk.Button btnRefresh;
	
	private global::Gtk.Label lbQstatus;

	protected virtual void Build ()
	{
		global::Stetic.Gui.Initialize (this);
		// Widget MainWindow
		this.Name = "MainWindow";
		this.Title = global::Mono.Unix.Catalog.GetString ("Authors catalog");
		this.WindowPosition = ((global::Gtk.WindowPosition)(4));
		this.BorderWidth = ((uint)(3));
		// Container child MainWindow.Gtk.Container+ContainerChild
		this.vbox1 = new global::Gtk.VBox ();
		this.vbox1.Name = "vbox1";
		this.vbox1.Spacing = 6;
		// Container child vbox1.Gtk.Box+BoxChild
		this.table1 = new global::Gtk.Table (((uint)(4)), ((uint)(2)), false);
		this.table1.Name = "table1";
		this.table1.RowSpacing = ((uint)(6));
		this.table1.ColumnSpacing = ((uint)(6));
		this.table1.BorderWidth = ((uint)(3));
		// Container child table1.Gtk.Table+TableChild
		this.calBirthdate = new global::Gtk.Calendar ();
		this.calBirthdate.CanFocus = true;
		this.calBirthdate.Name = "calBirthdate";
		this.calBirthdate.DisplayOptions = ((global::Gtk.CalendarDisplayOptions)(35));
		this.table1.Add (this.calBirthdate);
		global::Gtk.Table.TableChild w1 = ((global::Gtk.Table.TableChild)(this.table1 [this.calBirthdate]));
		w1.TopAttach = ((uint)(2));
		w1.BottomAttach = ((uint)(3));
		w1.LeftAttach = ((uint)(1));
		w1.RightAttach = ((uint)(2));
		w1.XOptions = ((global::Gtk.AttachOptions)(4));
		w1.YOptions = ((global::Gtk.AttachOptions)(4));
		// Container child table1.Gtk.Table+TableChild
		this.chkGender = new global::Gtk.CheckButton ();
		this.chkGender.CanFocus = true;
		this.chkGender.Name = "chkGender";
		this.chkGender.Label = global::Mono.Unix.Catalog.GetString ("Male");
		this.chkGender.DrawIndicator = true;
		this.chkGender.UseUnderline = true;
		this.table1.Add (this.chkGender);
		global::Gtk.Table.TableChild w2 = ((global::Gtk.Table.TableChild)(this.table1 [this.chkGender]));
		w2.TopAttach = ((uint)(3));
		w2.BottomAttach = ((uint)(4));
		w2.LeftAttach = ((uint)(1));
		w2.RightAttach = ((uint)(2));
		w2.XOptions = ((global::Gtk.AttachOptions)(4));
		w2.YOptions = ((global::Gtk.AttachOptions)(4));
		// Container child table1.Gtk.Table+TableChild
		this.label1 = new global::Gtk.Label ();
		this.label1.Name = "label1";
		this.label1.LabelProp = global::Mono.Unix.Catalog.GetString ("First name:");
		this.table1.Add (this.label1);
		global::Gtk.Table.TableChild w3 = ((global::Gtk.Table.TableChild)(this.table1 [this.label1]));
		w3.XOptions = ((global::Gtk.AttachOptions)(4));
		w3.YOptions = ((global::Gtk.AttachOptions)(4));
		// Container child table1.Gtk.Table+TableChild
		this.label2 = new global::Gtk.Label ();
		this.label2.Name = "label2";
		this.label2.LabelProp = global::Mono.Unix.Catalog.GetString ("Last name:");
		this.table1.Add (this.label2);
		global::Gtk.Table.TableChild w4 = ((global::Gtk.Table.TableChild)(this.table1 [this.label2]));
		w4.TopAttach = ((uint)(1));
		w4.BottomAttach = ((uint)(2));
		w4.XOptions = ((global::Gtk.AttachOptions)(4));
		w4.YOptions = ((global::Gtk.AttachOptions)(4));
		// Container child table1.Gtk.Table+TableChild
		this.label3 = new global::Gtk.Label ();
		this.label3.Name = "label3";
		this.label3.LabelProp = global::Mono.Unix.Catalog.GetString ("Birthdate:");
		this.table1.Add (this.label3);
		global::Gtk.Table.TableChild w5 = ((global::Gtk.Table.TableChild)(this.table1 [this.label3]));
		w5.TopAttach = ((uint)(2));
		w5.BottomAttach = ((uint)(3));
		w5.XOptions = ((global::Gtk.AttachOptions)(4));
		w5.YOptions = ((global::Gtk.AttachOptions)(4));
		// Container child table1.Gtk.Table+TableChild
		this.label6 = new global::Gtk.Label ();
		this.label6.Name = "label6";
		this.label6.LabelProp = global::Mono.Unix.Catalog.GetString ("Gender:");
		this.table1.Add (this.label6);
		global::Gtk.Table.TableChild w6 = ((global::Gtk.Table.TableChild)(this.table1 [this.label6]));
		w6.TopAttach = ((uint)(3));
		w6.BottomAttach = ((uint)(4));
		w6.XOptions = ((global::Gtk.AttachOptions)(4));
		w6.YOptions = ((global::Gtk.AttachOptions)(4));
		// Container child table1.Gtk.Table+TableChild
		this.txtFirstName = new global::Gtk.Entry ();
		this.txtFirstName.CanFocus = true;
		this.txtFirstName.Name = "txtFirstName";
		this.txtFirstName.IsEditable = true;
		this.txtFirstName.InvisibleChar = '•';
		this.table1.Add (this.txtFirstName);
		global::Gtk.Table.TableChild w7 = ((global::Gtk.Table.TableChild)(this.table1 [this.txtFirstName]));
		w7.LeftAttach = ((uint)(1));
		w7.RightAttach = ((uint)(2));
		w7.XOptions = ((global::Gtk.AttachOptions)(4));
		w7.YOptions = ((global::Gtk.AttachOptions)(4));
		// Container child table1.Gtk.Table+TableChild
		this.txtLastName = new global::Gtk.Entry ();
		this.txtLastName.CanFocus = true;
		this.txtLastName.Name = "txtLastName";
		this.txtLastName.IsEditable = true;
		this.txtLastName.InvisibleChar = '•';
		this.table1.Add (this.txtLastName);
		global::Gtk.Table.TableChild w8 = ((global::Gtk.Table.TableChild)(this.table1 [this.txtLastName]));
		w8.TopAttach = ((uint)(1));
		w8.BottomAttach = ((uint)(2));
		w8.LeftAttach = ((uint)(1));
		w8.RightAttach = ((uint)(2));
		w8.XOptions = ((global::Gtk.AttachOptions)(4));
		w8.YOptions = ((global::Gtk.AttachOptions)(4));
		this.vbox1.Add (this.table1);
		global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.table1]));
		w9.Position = 0;
		w9.Expand = false;
		w9.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.hbox1 = new global::Gtk.HBox ();
		this.hbox1.Name = "hbox1";
		this.hbox1.Spacing = 6;
		// Container child hbox1.Gtk.Box+BoxChild
		this.btnCreate = new global::Gtk.Button ();
		this.btnCreate.CanFocus = true;
		this.btnCreate.Name = "btnCreate";
		this.btnCreate.UseUnderline = true;
		this.btnCreate.Label = global::Mono.Unix.Catalog.GetString ("Add");
		this.hbox1.Add (this.btnCreate);
		global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.btnCreate]));
		w10.Position = 0;
		w10.Expand = false;
		w10.Fill = false;
		// Container child hbox1.Gtk.Box+BoxChild
		this.lbCstatus = new global::Gtk.Label ();
		this.lbCstatus.Name = "lbCstatus";
		this.hbox1.Add (this.lbCstatus);
		global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.lbCstatus]));
		w11.Position = 1;
		w11.Expand = false;
		w11.Fill = false;
		this.vbox1.Add (this.hbox1);
		global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox1]));
		w12.Position = 1;
		w12.Expand = false;
		w12.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
		this.GtkScrolledWindow.Name = "GtkScrolledWindow";
		this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
		// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
		this.gridAuthors = new global::Gtk.TreeView ();
		this.gridAuthors.CanFocus = true;
		this.gridAuthors.Name = "gridAuthors";
		this.GtkScrolledWindow.Add (this.gridAuthors);
		this.vbox1.Add (this.GtkScrolledWindow);
		global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.GtkScrolledWindow]));
		w14.Position = 2;
		// Container child vbox1.Gtk.Box+BoxChild
		this.hbox2 = new global::Gtk.HBox ();
		this.hbox2.Name = "hbox2";
		this.hbox2.Spacing = 6;
		// Container child hbox2.Gtk.Box+BoxChild
		this.btnRefresh = new global::Gtk.Button ();
		this.btnRefresh.CanFocus = true;
		this.btnRefresh.Name = "btnRefresh";
		this.btnRefresh.UseUnderline = true;
		this.btnRefresh.Label = global::Mono.Unix.Catalog.GetString ("Refresh grid");
		this.hbox2.Add (this.btnRefresh);
		global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.btnRefresh]));
		w15.Position = 0;
		w15.Expand = false;
		w15.Fill = false;
		// Container child hbox2.Gtk.Box+BoxChild
		this.lbQstatus = new global::Gtk.Label ();
		this.lbQstatus.Name = "lbQstatus";
		this.hbox2.Add (this.lbQstatus);
		global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.lbQstatus]));
		w16.Position = 1;
		w16.Expand = false;
		w16.Fill = false;
		this.vbox1.Add (this.hbox2);
		global::Gtk.Box.BoxChild w17 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox2]));
		w17.Position = 3;
		w17.Expand = false;
		w17.Fill = false;
		this.Add (this.vbox1);
		if ((this.Child != null)) {
			this.Child.ShowAll ();
		}
		this.DefaultWidth = 389;
		this.DefaultHeight = 471;
		this.Show ();
		this.DeleteEvent += new global::Gtk.DeleteEventHandler (this.OnDeleteEvent);
		this.btnCreate.Clicked += new global::System.EventHandler (this.OnBtnCreateClicked);
		this.btnRefresh.Clicked += new global::System.EventHandler (this.OnBtnRefreshClicked);
	}
}

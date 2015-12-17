module Main = 
    open System
    open Gtk
    open UnitsConvertor.AngleUnits
    open UnitsConvertor

    [<EntryPoint>]
    let Main(args) = 
        Application.Init()

        // Create new widgets.
        let win = new MainWindow.MyWindow()
        let box = new VBox(false, 1)
        let lblFrom = new Label("From:")
        let cmbFrom = new ComboBox([|"Degree"; "Gradian"; "Radian"|])
        let txtFrom = new Entry()
        let lblTo = new Label("To:")
        let cmbTo = new ComboBox([|"Degree"; "Gradian"; "Radian"|])
        let txtTo = new Entry()

        // Set widgets properties.
        win.Title <- "Angle Units Convertor"
        win.Resize(350,200)
        lblFrom.Xalign <- 0.0f
        lblTo.Xalign <- 0.0f
        cmbFrom.Active <- 0
        cmbTo.Active <- 0
        txtTo.IsEditable <- false
        txtFrom.Text <- "0"
        txtTo.Text <- "0"

        // A function to convert units.
        let convertUnits() = 
            try
                let unitFrom = cmbFrom.ActiveText
                let unitTo = cmbTo.ActiveText
                let angle = txtFrom.Text
                match unitFrom, unitTo with
                | "Degree", "Gradian" -> 
                        txtTo.Text <- (DegToGra (float angle * 1.0<deg>)).ToString()
                | "Degree", "Radian"  -> 
                        txtTo.Text <- (DegToRad (float angle * 1.0<deg>)).ToString()
                | "Gradian", "Degree" -> 
                        txtTo.Text <- (GraToDeg (float angle * 1.0<gra>)).ToString()
                | "Gradian", "Radian" -> 
                        txtTo.Text <- (GraToRad (float angle * 1.0<gra>)).ToString()
                | "Radian", "Degree"  -> 
                        txtTo.Text <- (RadToDeg (float angle * 1.0<rad>)).ToString()
                | "Radian", "Gradian" -> 
                        txtTo.Text <- (RadToGra (float angle * 1.0<rad>)).ToString()
                | _                   -> 
                        txtTo.Text <- txtFrom.Text 
            with 
                | exp -> txtTo.Text <- "Error! ;/"

        // Events handle.
        txtFrom.Changed.Add(fun _-> convertUnits())
        cmbFrom.Changed.Add(fun _-> convertUnits())
        cmbTo.Changed.Add(fun _-> convertUnits())

        // Add widgets to main container.
        box.Add(lblFrom)
        box.Add(cmbFrom)
        box.Add(txtFrom)
        box.Add(lblTo)
        box.Add(cmbTo)
        box.Add(txtTo)

        // Add main container to window.
        win.Add(box)

        // Draw anythings
        win.ShowAll() 
        Application.Run()
        0 
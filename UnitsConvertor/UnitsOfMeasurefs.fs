namespace UnitsConvertor 
open System 

module AngleUnits = 
    [<Measure>] type deg 
    [<Measure>] type gra 
    [<Measure>] type rad

    let DegToGra (angle : float<deg>) = float angle * 1.11111111<gra> 
    let DegToRad (angle : float<deg>) = (float angle * Math.PI / 180.0) * 1.0<rad> 
    let GraToDeg (angle : float<gra>) = float angle * 0.9<deg> 
    let GraToRad (angle : float<gra>) = float angle * 0.0157075<rad> 
    let RadToGra (angle : float<rad>) = float angle * 63.6638548<gra> 
    let RadToDeg (angle : float<rad>) = (float angle * 180.0 / Math.PI) * 1.0<deg>

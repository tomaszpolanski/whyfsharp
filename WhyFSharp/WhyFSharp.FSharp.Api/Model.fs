module Model

type TwoDPointF = { X : int; Y : int } override this.ToString() = sprintf "%A" this
    
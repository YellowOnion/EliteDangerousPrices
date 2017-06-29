namespace Project7.Parser

module Parsers =

    open FParsec
    open FParsec.Primitives
    open FParsec.CharParsers
    open Project7.Model

    exception ParseError of string
    
    type SystemResult = { Name : string; X: float; Y: float; Z: float }
    let SystemResult n x y z = {Name = n; X=x; Y=y; Z=z }

    let test p str (sys:StarSystem) =
        match run p str with
        | Success(result, _, _)   -> (let {Name=n; X=x; Y=y; Z=z} = result
                                      sys.Name <- n;
                                      sys.X <- x;
                                      sys.Y <- y;
                                      sys.Z <- z;
                                      sys)
        | Failure(errorMsg, _, _) -> raise (ParseError(errorMsg))
    
    let str s = pstring s
    let strLit sep = str "'" >>. (manyCharsTill (noneOf ("'"+sep)) (pchar '\''))

    let delim = ","
    //let testStrLit s sys = test (strLit delim) s sys

    let TCSV sep = pipe4 (strLit sep .>> str sep) (pfloat .>> str sep) (pfloat .>> str sep) (pfloat) (SystemResult)
    let testTCSV s sys = test (TCSV delim) s sys
    // let csv = pstring str >>. 
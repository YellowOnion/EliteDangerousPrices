namespace Project7.Parser

module Parsers =

    open FParsec
    open FParsec.Primitives
    open FParsec.CharParsers
    open Project7.Model

    exception ParseError of string
    
    let test p str =
      match run p str with
    |   Success(result, _, _)   -> printfn "Success: %A" result
    |   Failure(errorMsg, _, _) -> printfn "Failure: %s" errorMsg
    
    let str s = pstring s
    let delim = ','
    let strLit sep = between (str "'") (str "'")
                             (stringsSepBy (manySatisfy (fun c -> c <> '\'' && c <> sep))
                                       (str "''" |>> (function
                                                       | "''" -> "'")))


    type SystemResult = { Name : string; X: float; Y: float; Z: float }
    let SystemResult n x y z = {Name = n; X=x; Y=y; Z=z }

    let SystemCSV sep = let seps = string sep 
                        pipe4 (strLit sep .>> str seps) (pfloat .>> str seps) (pfloat .>> str seps) (pfloat) (SystemResult)

    let runSystemCSVParser s (sys:StarSystem) =
        match run (SystemCSV delim) s with
        | Success(result, _, _)   -> (let {Name=n; X=x; Y=y; Z=z} = result
                                      sys.StarName <- n;
                                      sys.X <- x;
                                      sys.Y <- y;
                                      sys.Z <- z;
                                      sys)
        | Failure(errorMsg, _, _) -> raise (ParseError(errorMsg))
    
    type StationResult = { Name: string; StarSystem: string }
    let StationResult s n = {Name = n; StarSystem=s}

    let StationCSV sep = let seps = string sep
                         pipe2 (strLit sep .>> str seps) (strLit sep .>> str seps) (StationResult)

    let runStationCSVParser s =
        match run (StationCSV delim) s with 
        | Success(result, _, _) -> result
        | Failure(errorMsg, _, _) -> raise (ParseError(errorMsg))
    
    type StationCResult = {UniqueName: string; commodities: ResizeArray<Commodity>}
    let StationCResult uname (commods:seq<Commodity>) = {UniqueName = uname; commodities = ResizeArray<Commodity> commods }

    let comment = (str "#" >>. restOfLine true) |>> ignore

    let ws = many1 (spaces1 <|> comment) |>> ignore <?> "whitespace"
    let sep = skipMany1 (anyOf " \t") 
    let cname = pstringCI "ADVANCED CATALYSERS" <|>
                pstringCI "ADVANCED MEDICINES" <|>
                pstringCI "AGRI-MEDICINES" <|>
                pstringCI "AI RELICS" <|>
                pstringCI "ALGAE" <|>
                pstringCI "ALUMINIUM" <|>
                pstringCI "ANCIENT ARTEFACT" <|>
                pstringCI "ANIMAL MEAT" <|>
                pstringCI "ANIMAL MONITORS" <|>
                pstringCI "ANTIMATTER CONTAINMENT UNIT" <|>
                pstringCI "ANTIQUITIES" <|>
                pstringCI "AQUAPONIC SYSTEMS" <|>
                pstringCI "ARTICULATION MOTORS" <|>
                pstringCI "ASSAULT PLANS" <|>
                pstringCI "ATMOSPHERIC PROCESSORS" <|>
                pstringCI "AUTO-FABRICATORS" <|>
                pstringCI "BASIC MEDICINES" <|>
                pstringCI "BATTLE WEAPONS" <|>
                pstringCI "BAUXITE" <|>
                pstringCI "BEER" <|>
                pstringCI "BERTRANDITE" <|>
                pstringCI "BERYLLIUM" <|>
                pstringCI "BIOREDUCING LICHEN" <|>
                pstringCI "BIOWASTE" <|>
                pstringCI "BISMUTH" <|>
                pstringCI "BLACK BOX" <|>
                pstringCI "BOOTLEG LIQUOR" <|>
                pstringCI "BROMELLITE" <|>
                pstringCI "BUILDING FABRICATORS" <|>
                pstringCI "CERAMIC COMPOSITES" <|>
                pstringCI "CHEMICAL WASTE" <|>
                pstringCI "CLOTHING" <|>
                pstringCI "CMM COMPOSITE" <|>
                pstringCI "COBALT" <|>
                pstringCI "COFFEE" <|>
                pstringCI "COLTAN" <|>
                pstringCI "COMBAT STABILISERS" <|>
                pstringCI "COMMERCIAL SAMPLES" <|>
                pstringCI "COMPUTER COMPONENTS" <|>
                pstringCI "CONDUCTIVE FABRICS" <|>
                pstringCI "CONSUMER TECHNOLOGY" <|>
                pstringCI "COOLING HOSES" <|>
                pstringCI "COPPER" <|>
                pstringCI "CROP HARVESTERS" <|>
                pstringCI "CRYOLITE" <|>
                pstringCI "DATA CORE" <|>
                pstringCI "DIPLOMATIC BAG" <|>
                pstringCI "DOMESTIC APPLIANCES" <|>
                pstringCI "EMERGENCY POWER CELLS" <|>
                pstringCI "ENCRYPTED CORRESPONDENCE" <|>
                pstringCI "ENCRYPTED DATA STORAGE" <|>
                pstringCI "ENERGY GRID ASSEMBLY" <|>
                pstringCI "EVACUATION SHELTER" <|>
                pstringCI "EXHAUST MANIFOLD" <|>
                pstringCI "EXPERIMENTAL CHEMICALS" <|>
                pstringCI "EXPLOSIVES" <|>
                pstringCI "FISH" <|>
                pstringCI "FOOD CARTRIDGES" <|>
                pstringCI "FOSSIL REMNANTS" <|>
                pstringCI "FRUIT AND VEGETABLES" <|>
                pstringCI "GALACTIC TRAVEL GUIDE" <|>
                pstringCI "GALLITE" <|>
                pstringCI "GALLIUM" <|>
                pstringCI "GEOLOGICAL EQUIPMENT" <|>
                pstringCI "GEOLOGICAL SAMPLES" <|>
                pstringCI "GOLD" <|>
                pstringCI "GOSLARITE" <|>
                pstringCI "GRAIN" <|>
                pstringCI "H.E. SUITS" <|>
                pstringCI "HAFNIUM 178" <|>
                pstringCI "HARDWARE DIAGNOSTIC SENSOR" <|>
                pstringCI "HEATSINK INTERLINK" <|>
                pstringCI "HN SHOCK MOUNT" <|>
                pstringCI "HOSTAGE" <|>
                pstringCI "HYDROGEN FUEL" <|>
                pstringCI "HYDROGEN PEROXIDE" <|>
                pstringCI "IMPERIAL SLAVES" <|>
                pstringCI "INDITE" <|>
                pstringCI "INDIUM" <|>
                pstringCI "INSULATING MEMBRANE" <|>
                pstringCI "ION DISTRIBUTOR" <|>
                pstringCI "JADEITE" <|>
                pstringCI "LAND ENRICHMENT SYSTEMS" <|>
                pstringCI "LANDMINES" <|>
                pstringCI "LANTHANUM" <|>
                pstringCI "LEATHER" <|>
                pstringCI "LEPIDOLITE" <|>
                pstringCI "LIQUID OXYGEN" <|>
                pstringCI "LIQUOR" <|>
                pstringCI "LITHIUM HYDROXIDE" <|>
                pstringCI "LITHIUM" <|>
                pstringCI "LOW TEMPERATURE DIAMONDS" <|>
                pstringCI "MAGNETIC EMITTER COIL" <|>
                pstringCI "MARINE EQUIPMENT" <|>
                pstringCI "MEDICAL DIAGNOSTIC EQUIPMENT" <|>
                pstringCI "META-ALLOYS" <|>
                pstringCI "METHANE CLATHRATE" <|>
                pstringCI "METHANOL MONOHYDRATE" <|>
                pstringCI "MICRO CONTROLLERS" <|>
                pstringCI "MICRO-WEAVE COOLING HOSES" <|>
                pstringCI "MICROBIAL FURNACES" <|>
                pstringCI "MILITARY GRADE FABRICS" <|>
                pstringCI "MILITARY INTELLIGENCE" <|>
                pstringCI "MILITARY PLANS" <|>
                pstringCI "MINERAL EXTRACTORS" <|>
                pstringCI "MINERAL OIL" <|>
                pstringCI "MODULAR TERMINALS" <|>
                pstringCI "MOISSANITE" <|>
                pstringCI "MUON IMAGER" <|>
                pstringCI "MYSTERIOUS IDOL" <|>
                pstringCI "NANOBREAKERS" <|>
                pstringCI "NARCOTICS" <|>
                pstringCI "NATURAL FABRICS" <|>
                pstringCI "NEOFABRIC INSULATION" <|>
                pstringCI "NEOFABRIC INSULATION" <|>
                pstringCI "NERVE AGENTS" <|>
                pstringCI "NON-LETHAL WEAPONS" <|>
                pstringCI "OCCUPIED CRYOPOD" <|>
                pstringCI "OCCUPIED ESCAPE POD" <|>
                pstringCI "OSMIUM" <|>
                pstringCI "PAINITE" <|>
                pstringCI "PALLADIUM" <|>
                pstringCI "PERFORMANCE ENHANCERS" <|>
                pstringCI "PERSONAL EFFECTS" <|>
                pstringCI "PERSONAL WEAPONS" <|>
                pstringCI "PESTICIDES" <|>
                pstringCI "PLATINUM" <|>
                pstringCI "POLITICAL PRISONER" <|>
                pstringCI "POLYMERS" <|>
                pstringCI "POWER CONVERTER" <|>
                pstringCI "POWER GENERATORS" <|>
                pstringCI "POWER TRANSFER BUS" <|>
                pstringCI "PRASEODYMIUM" <|>
                pstringCI "PROGENITOR CELLS" <|>
                pstringCI "PROHIBITED RESEARCH MATERIALS" <|>
                pstringCI "PROTOTYPE TECH" <|>
                pstringCI "PYROPHYLLITE" <|>
                pstringCI "RADIATION BAFFLE" <|>
                pstringCI "RARE ARTWORK" <|>
                pstringCI "REACTIVE ARMOUR" <|>
                pstringCI "REBEL TRANSMISSIONS" <|>
                pstringCI "REINFORCED MOUNTING PLATE" <|>
                pstringCI "RESONATING SEPARATORS" <|>
                pstringCI "ROBOTICS" <|>
                pstringCI "RUTILE" <|>
                pstringCI "SALVAGEABLE WRECKAGE" <|>
                pstringCI "SAMARIUM" <|>
                pstringCI "SAP 8 CORE CONTAINER" <|>
                pstringCI "SCIENTIFIC RESEARCH" <|>
                pstringCI "SCIENTIFIC SAMPLES" <|>
                pstringCI "SCRAP" <|>
                pstringCI "SEMICONDUCTORS" <|>
                pstringCI "SILVER" <|>
                pstringCI "SKIMMER COMPONENTS" <|>
                pstringCI "SLAVES" <|>
                pstringCI "SPACE PIONEER RELICS" <|>
                pstringCI "STRUCTURAL REGULATORS" <|>
                pstringCI "SUPERCONDUCTORS" <|>
                pstringCI "SURFACE STABILISERS" <|>
                pstringCI "SURVIVAL EQUIPMENT" <|>
                pstringCI "SYNTHETIC FABRICS" <|>
                pstringCI "SYNTHETIC MEAT" <|>
                pstringCI "SYNTHETIC REAGENTS" <|>
                pstringCI "TAAFFEITE" <|>
                pstringCI "TACTICAL DATA" <|>
                pstringCI "TANTALUM" <|>
                pstringCI "TEA" <|>
                pstringCI "TECHNICAL BLUEPRINTS" <|>
                pstringCI "TELEMETRY SUITE" <|>
                pstringCI "THALLIUM" <|>
                pstringCI "THERMAL COOLING UNITS" <|>
                pstringCI "THORIUM" <|>
                pstringCI "TITANIUM" <|>
                pstringCI "TOBACCO" <|>
                pstringCI "TOXIC WASTE" <|>
                pstringCI "TRADE DATA" <|>
                pstringCI "TRINKETS OF HIDDEN FORTUNE" <|>
                pstringCI "UNKNOWN ARTEFACT" <|>
                pstringCI "UNSTABLE DATA CORE" <|>
                pstringCI "URANINITE" <|>
                pstringCI "URANIUM" <|>
                pstringCI "WATER PURIFIERS" <|>
                pstringCI "WATER" <|>
                pstringCI "WINE"


    let stock = pint32 .>> skipAnyOf "HML?" <|> (str "?" <|> str "-" >>. preturn 0)
    let pcommodity = str "      " >>. parse { let! n = cname
                                              do! sep
                                              let! sell = pint32
                                              do! sep
                                              let! buy = pint32
                                              do! sep
                                              let! demand = stock
                                              do! sep
                                              let! supply = stock
                                              return (new Commodity(CName = n, Buy = buy, Sell = sell, Stock = supply)) }

    let category = str "   +" >>. restOfLine true
    let sname = str "@ " >>. restOfLine true
    let commodity = pcommodity .>> restOfLine false
    let manyCommodities = category >>. sepBy1 (commodity) (attempt (newline .>> notFollowedByNewline .>> notFollowedByEof) .>> optional category)


    let station = pipe2 sname manyCommodities StationCResult
    let pricesParser = ws >>. ((sepBy1 station (attempt (newline >>. notFollowedByEof) .>> newline)) .>> newline .>> eof) |>> ResizeArray<StationCResult>

    let testComment = printf "comment: "; test comment "# oeuigdouigedioeuiduid \n"
    let testSName = printf "sname: "; test sname "@ 1 G. CAELI/Smoot Gateway\n"
    let testCName = printf "cname: "; test cname "HYDROGEN FUEL"
    let testStock = printf "stock: "; test stock "-"; test stock "?" ; test stock "12414H"
    let testSep = printf "sep: "; test sep "             \t     0"
    let testPComm = printf "com: " ;test pcommodity "      EXPLOSIVES                           331       0     27187M          -  2017-06-30 10:45:08 # IXian Probe_E:D Market Connector [Windows]_2.3.3.0\n"
    let testManyCom = printf "mcom: "; 
                      test manyCommodities "   + Chemicals
      EXPLOSIVES                           331       0     27187M          -  2017-06-30 10:45:08 # IXian Probe_E:D Market Connector [Windows]_2.3.3.0
      HYDROGEN FUEL                     108     113          ?     67372L  2017-06-30 10:45:08 # IXian Probe_E:D Market Connector [Windows]_2.3.3.0
      HYDROGEN PEROXIDE             805       0    206296H          -  2017-06-30 10:45:08 # IXian Probe_E:D Market Connector [Windows]_2.3.3.0
      LIQUID OXYGEN                     209       0    378975H          -  2017-06-30 10:45:08 # IXian Probe_E:D Market Connector [Windows]_2.3.3.0
      WATER                                     179       0    108463H          -  2017-06-30 10:45:08 # IXian Probe_E:D Market Connector [Windows]_2.3.3.0
   + Consumer Items
      CLOTHING                               307       0     16615M          -  2017-06-30 10:45:08 # IXian Probe_E:D Market Connector [Windows]_2.3.3.0
      CONSUMER TECHNOLOGY         7083       0      7258M          -  2017-06-30 10:45:08 # IXian Probe_E:D Market Connector [Windows]_2.3.3.0
      DOMESTIC APPLIANCES         558       0      6479M          -  2017-06-30 10:45:08 # IXian Probe_E:D Market Connector [Windows]_2.3.3.0
      SURVIVAL EQUIPMENT           351     369          ?      1250M  2017-06-30 10:45:08 # IXian Probe_E:D Market Connector [Windows]_2.3.3.0"

    let testWs = test (ws >>. str "s") "#1 oeuou \n \n #2oeuou \ns"
    //let testStation = printf "station: "; test station "

    let testAll = testComment; testSName; testStock; testSep; testPComm; testWs; testManyCom

    let runPricesFileParser f e =
        match runParserOnFile pricesParser () f e with
        | Success(result, _, _) -> result
        | Failure(errorMsg, _, _) -> printfn "Failure: %s" errorMsg; raise (ParseError(errorMsg))

namespace Structurizr

type CodeElementRole =
    | Primary
    | Supporting

type CodeElement =
    { Name: string
      Type: string
      Language: string
      Role: CodeElementRole }

    static member ForTypeName(fullyQualifiedTypeName: string) =
        let typeName =
            fullyQualifiedTypeName.Substring(0, fullyQualifiedTypeName.IndexOf(","))

        let dot = typeName.LastIndexOf('.')

        { Name = if dot > -1 then typeName.Substring(dot + 1) else typeName
          Type = fullyQualifiedTypeName
          Language = "C#"
          Role = Primary }



// member this.Description: string with
//     get()
//     set(value) =

// member this.Category: string with get, set
// member Visibility: string
// member Size: int

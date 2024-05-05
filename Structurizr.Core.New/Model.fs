namespace Structurizr

open System.Runtime.Serialization
open System

type CodeElementRole =
    | Primary
    | Supporting

[<DataContract>]
[<CustomEquality>]
[<CustomComparison>]
type Perspective =
    { Name: string
      Description: string }

    interface IComparable<Perspective> with
        member this.CompareTo(other: Perspective) = this.Name.CompareTo(other.Name)

    override this.Equals(obj) =
        match obj with
        | :? Perspective as other -> this.Name = other.Name
        | _ -> false

    override this.GetHashCode() = this.Name.GetHashCode()

[<DataContract>]
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

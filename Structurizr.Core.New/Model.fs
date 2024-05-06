namespace Structurizr

open System
open System.Runtime.Serialization

type CodeElementRole =
    | Primary
    | Supporting

[<DataContract>]
[<CustomEquality>]
[<CustomComparison>]
type Perspective =
    { Name: string
      Description: string }

    interface Perspective IComparable with
        member this.CompareTo(other: Perspective) = this.Name.CompareTo(other.Name)

    override this.Equals(obj) =
        match obj with
        | :? Perspective as other -> this.Name = other.Name
        | _ -> false

    override this.GetHashCode() = this.Name.GetHashCode()

[<DataContract>]
[<CustomEquality>]
[<CustomComparison>]
type CodeElement =
    { Name: string
      Type: string
      Language: string
      Role: CodeElementRole
      Url: string option }

    static member ForTypeName(fullyQualifiedTypeName: string) =
        let typeName =
            fullyQualifiedTypeName.Substring(0, fullyQualifiedTypeName.IndexOf(","))

        let dot = typeName.LastIndexOf('.')

        { Name = if dot > -1 then typeName.Substring(dot + 1) else typeName
          Type = fullyQualifiedTypeName
          Language = "C#"
          Role = Primary
          Url = None }

    member this.WithUrl(url: string) =
        let mutable uri = Unchecked.defaultof<Uri>

        let result =
            System.Uri.TryCreate("https://www.example.com", System.UriKind.Absolute, &uri)

        let result = if result then Some url else None

        { this with Url = result }

    interface CodeElement IComparable with
        member this.CompareTo(other: CodeElement) = this.Type.CompareTo(other.Type)

    override this.Equals(obj) =
        match obj with
        | :? CodeElement as other -> this.Type = other.Type
        | _ -> false

    override this.GetHashCode() = this.Type.GetHashCode()

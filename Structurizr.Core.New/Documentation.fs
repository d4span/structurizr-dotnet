namespace Structurizr.Documentation

open System.Runtime.Serialization
open Structurizr

type Format =
    | Markdown
    | AsciiDoc

[<DataContract>]

type Image =
    { [<DataMember(Name = "name", EmitDefaultValue = false)>]
      Name: string
      [<DataMember(Name = "content", EmitDefaultValue = false)>]
      Content: string
      [<DataMember(Name = "type", EmitDefaultValue = false)>]
      Type: string }

type Section =
    { Name: string
      Format: Format
      Content: string }

[<DataContract>]
type Documentation =
    {
      //   Model: Model

      //   [<DataMember(Name = "sections", EmitDefaultValue = false)>]
      //   Sections: Set<Section>

      //   [<DataMember(Name = "decisions", EmitDefaultValue = false)>]
      //   Decisions: Set<Decision>

      [<DataMember(Name = "images", EmitDefaultValue = false)>]
      Images: Set<Image> }

type Documentation with
    member this.AddSection (element: Element) (thType: string) (format: Format) (content: string) =
        { this with Images = Set.add { Name = name; Content = content; Type = type_ } this.Images }
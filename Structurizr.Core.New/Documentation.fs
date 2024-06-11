namespace Structurizr.Documentation

open System
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

[<StructuralComparison>]
[<StructuralEquality>]
[<DataContract>]
type Section =
    { Element: Element
      [<DataMember(Name = "elementId", EmitDefaultValue = false)>]
      ElementId: string
      [<DataMember(Name = "title", EmitDefaultValue = true)>]
      Title: string
      [<DataMember(Name = "type", EmitDefaultValue = true)>]
      sectionType: string
      [<DataMember(Name = "order", EmitDefaultValue = true)>]
      Order: int
      [<DataMember(Name = "format", EmitDefaultValue = true)>]
      Format: Format
      [<DataMember(Name = "content", EmitDefaultValue = false)>]
      Content: string }

[<DataContract>]
type Documentation =
    { Model: Model

      [<DataMember(Name = "sections", EmitDefaultValue = false)>]
      Sections: Set<Section>

      //   [<DataMember(Name = "decisions", EmitDefaultValue = false)>]
      //   Decisions: Set<Decision>

      [<DataMember(Name = "images", EmitDefaultValue = false)>]
      Images: Set<Image> }

type Documentation with

    member this.AddSection (element: Element) (title: string) (format: Format) (content: string) =
        let isNotEmpty = fun s -> s |> String.IsNullOrWhiteSpace |> not

        (title, content)
        |> Some
        |> Option.filter (fun (title, _) -> title |> isNotEmpty)
        |> Option.filter (fun (_, content) -> content |> isNotEmpty)

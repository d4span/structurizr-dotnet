namespace Structurizr.Documentation

open System.Runtime.Serialization

type Image =
    { [<DataMember(Name = "name", EmitDefaultValue = false)>]
      Name: string
      [<DataMember(Name = "content", EmitDefaultValue = false)>]
      Content: string
      [<DataMember(Name = "type", EmitDefaultValue = false)>]
      Type: string }

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

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

namespace Structurizr

open System
open System.Runtime.Serialization

type Role =
    | ReadWrite
    | ReadOnly

[<DataContract>]
type User =
    { [<DataMember(Name = "username", EmitDefaultValue = false)>]
      Username: string
      [<DataMember(Name = "role", EmitDefaultValue = false)>]
      Role: string }

[<DataContract>]
type WorkspaceConfiguration =
    { [<DataMember(Name = "users", EmitDefaultValue = false)>]
      Users: Set<User> }

[<DataContract>]
[<Interface>]
type AbstractWorkspace =
    [<DataMember(Name = "id", EmitDefaultValue = false)>]
    abstract Id: int with get

    [<DataMember(Name = "name", EmitDefaultValue = false)>]
    abstract Name: string with get

    [<DataMember(Name = "description", EmitDefaultValue = false)>]
    abstract Description: string with get

    [<DataMember(Name = "lastModifiedDate", EmitDefaultValue = false)>]
    abstract LastModifiedDate: DateTime with get

    [<DataMember(Name = "lastModifiedUser", EmitDefaultValue = false)>]
    abstract LastModifiedUser: string with get

    [<DataMember(Name = "lastModifiedAgent", EmitDefaultValue = false)>]
    abstract LastModifiedAgent: string with get

    [<DataMember(Name = "version", EmitDefaultValue = false)>]
    abstract Version: string with get

    [<DataMember(Name = "revision", EmitDefaultValue = false)>]
    abstract Revision: int with get

    [<DataMember(Name = "thumbnail", EmitDefaultValue = false)>]
    abstract Thumbnail: string with get

    [<DataMember(Name = "configuration", EmitDefaultValue = false)>]
    abstract Configuration: WorkspaceConfiguration with get

[<DataContract>]
type Workspace =
    { Id: int
      Name: string
      Description: string
      LastModifiedDate: DateTime
      LastModifiedUser: string
      LastModifiedAgent: string
      Version: string
      Revision: int
      Thumbnail: string
      Configuration: WorkspaceConfiguration
      // [<DataMember(Name = "model", EmitDefaultValue = false)>]
      // Model: Model
      // [<DataMember(Name = "views", EmitDefaultValue = false)>]
      // Views: ViewSet
      [<DataMember(Name = "documentation", EmitDefaultValue = false)>]
      Documentation: Documentation.Documentation }

    interface AbstractWorkspace with
        member this.Id = this.Id
        member this.Name = this.Name
        member this.Description = this.Description
        member this.LastModifiedDate = this.LastModifiedDate
        member this.LastModifiedUser = this.LastModifiedUser
        member this.LastModifiedAgent = this.LastModifiedAgent
        member this.Version = this.Version
        member this.Revision = this.Revision
        member this.Thumbnail = this.Thumbnail
        member this.Configuration = this.Configuration

namespace Structurizr

open System
open System.Runtime.Serialization
open FSharp.Collections

// type IModelItem =
//     abstract Id: string
//     abstract Tags: string list

type Location =
    | Unspecified
    | Internal
    | External

// type CodeElementRole =
//     | Primary
//     | Supporting

// type InteractionStyle =
//     | Synchronous
//     | Asynchronous

// type Uri(value: string) =
//     inherit System.Uri(value)

//     override this.Equals(other: obj) =
//         match other with
//         | :? Uri as other -> (this :> System.Uri).Equals(other)
//         | _ -> false

//     override this.GetHashCode() = (this :> System.Uri).GetHashCode()

//     interface IComparable with
//         member this.CompareTo(other: obj) =
//             match other with
//             | :? Uri as other -> (this :> IComparable<Uri>).CompareTo(other)
//             | _ -> invalidArg "other" "The argument must be a Uri"

//     interface IComparable<Uri> with
//         member this.CompareTo(other: Uri) =
//             this.ToString().CompareTo(other.ToString())

// type CodeElement =
//     { Role: CodeElementRole
//       Name: string
//       Type: string
//       Description: string
//       Uri: Uri
//       Language: string
//       Category: string
//       Visibility: string
//       Size: int }

type Person = { Location: Location }

// type Component =
//     { Technology: string
//       Size: int
//       CodeElements: Set<CodeElement> }

// type Container = { Technology: string }

// type SoftwareSystem = { Location: Location }

// type StaticStructureElement =
//     | Person of Person
//     | Component
//     | Container of Container
//     | SoftwareSystem of SoftwareSystem

// type GroupableElement = StaticStructureElement of StaticStructureElement

// type StaticStructureElementInstance =
//     | ContainerInstance
//     | SoftwareSystemInstance

// type DeploymentElement =
//     | StaticStructureElementInstance of StaticStructureElementInstance
//     | InfrastructureNode
//     | DeploymentNode

[<DataContract>]
[<Interface>]
type Element =
    [<DataMember(Name = "name", EmitDefaultValue = false)>]
    abstract Name: string with get

    [<DataMember(Name = "description", EmitDefaultValue = false)>]
    abstract Description: string with get

    inherit IComparable
//    | DeploymentElement // of DeploymentElement
//    | GroupableElement // of GroupableElement

// type ModelItem =
//     | Element of Element
//     | Relationship of
//         Description: string *
//         SourceId: string *
//         DestinationId: string *
//         Source: Element *
//         Destination: Element *
//         Technology: string *
//         LinkedRelationshipId: string *
//         InteractionStyle: InteractionStyle option *
//         Url: string

//     interface IModelItem

type Model =
    {
      // ImpliedRelationshipsStrategy: IImpliedRelationshipsStrategy *
      // IdGenerator: IdGenerator *
      // Enterprise: Enterprise option *
      People: Set<Person>
    // SoftwareSystems: Set<SoftwareSystem> *
    // DeploymentNodes: Set<DeploymentNode> *
    // Relationships: Relationship list
    }

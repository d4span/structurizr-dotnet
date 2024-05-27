namespace Structurizr

open System
open FSharp.Collections

type IModelItem =
    abstract Id: string
    abstract Tags: string list

type Location =
    | Unspecified
    | Internal
    | External

type CodeElementRole =
    | Primary
    | Supporting

type Url(url: string) =
    let _ = Uri(url)
    member _.Url = url

    interface IComparable<Url> with
        member _.CompareTo(other: Url) =
            String.Compare(url, other.Url)

[<StructuralComparison>]
type CodeElement =
    { Role: CodeElementRole
      Name: string
      Type: string
      Description: string
      Url: Url
      Language: string
      Category: string
      Visibility: string
      Size: int }

type Person = { Location: Location }

type Component = { Technology: string; Size: int; CodeElements: Set<CodeElement>}

type Container = { Technology: string }

type SoftwareSystem = { Location: Location }

type StaticStructureElement =
    | Person of Person
    | Component
    | Container of Container
    | SoftwareSystem of SoftwareSystem

type GroupableElement = StaticStructureElement of StaticStructureElement

type StaticStructureElementInstance =
    | ContainerInstance
    | SoftwareSystemInstance

type DeploymentElement =
    | StaticStructureElementInstance of StaticStructureElementInstance
    | InfrastructureNode
    | DeploymentNode

type Element =
    | DeploymentElement of DeploymentElement
    | GroupableElement of GroupableElement

type ModelItem =
    | Element of Element
    | Relationship of
        Description: string *
        SourceId: string *
        DestinationId: string *
        Source: Element *
        Destination: Element *
        Technology: string *
        LinkedRelationshipId: string *
        InteractionStyle: InteractionStyle option *
        Url: string

    interface IModelItem

type Model =
    | Model of
        ImpliedRelationshipsStrategy: IImpliedRelationshipsStrategy *
        IdGenerator: IdGenerator *
        Enterprise: Enterprise option *
        People: Set<Person> *
        SoftwareSystems: Set<SoftwareSystem> *
        DeploymentNodes: Set<DeploymentNode> *
        Relationships: Relationship list

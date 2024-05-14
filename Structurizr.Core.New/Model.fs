namespace Structurizr.Core.New

open FSharp.Collections
open Structurizr

type Model =
    { ImpliedRelationshipsStrategy: IImpliedRelationshipsStrategy
      IdGenerator: IdGenerator
      Enterprise: Enterprise
      People: Set<Person>
      SoftwareSystems: Set<SoftwareSystem> 
      DeploymentNodes: Set<DeploymentNode> 
      Relationships: Relationship list }

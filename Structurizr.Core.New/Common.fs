namespace Structurizr

open System

type IdentifierMode =
    | Hierarchical
    | Flat

type 'E GroupBlock =
    { Name: string
      elements: 'E list
      subgroups: 'E GroupBlock list }

type Tags = Set<string>

type Description = string

type Url = Uri

type Property = { Name: string; Value: string }

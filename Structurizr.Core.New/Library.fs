namespace Structurizr

type Documentation = { Path: string; Class: string option }

type ADR = { Path: string; Class: string option }

type Extension =
    | File of string
    | Url of string

type Workspace =
    { Name: string Option
      Description: string Option
      Extends: Extension option
      Model: ModelBlock
      Views: ViewBlock
      ``!Identifiers``: IdentifierMode
      ``!Docs``: Documentation list
      ``!ADR``: ADR list
      Properties: Property list
      Configuration: Configuration list }

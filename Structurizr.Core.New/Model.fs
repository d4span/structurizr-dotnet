namespace Structurizr


type Person =
    { Name: string
      Description: string option
      Tags: Tags
       }

type ModelGroupElement =
    | PersonElement of Person
    | SoftwareSystemElement of SoftwareSystem

type ModelBlock =
    { ``!Identifiers``: IdentifierMode
      Group: ModelGroupElement GroupBlock list
      Person: Set<Person> }

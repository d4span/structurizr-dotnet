namespace Structurizr

module CanonicalNameGenerator =

    module UriSchemes =
        let CustomElementType = "Custom://"
        let PersonType = "Person://"
        let SoftwareSystemType = "SoftwareSystem://"
        let ContainerType = "Container://"
        let ComponentType = "Component://"

        let DeploymentNodeType = "DeploymentNode://"
        let InfrastructureNodeType = "InfrastructureNode://"
        let ContainerInstanceType = "ContainerInstance://"
        let SoftwareSystemInstanceType = "SoftwareSystemInstance://"

    let StaticCanonicalNameSeperator = "."
    let DeploymentCanonicalNameSeperator = "/"

    let formatName (name: string) =
        name
            .Replace(StaticCanonicalNameSeperator, "")
            .Replace(DeploymentCanonicalNameSeperator, "")

    let formatNameOfElement (element: Element) = formatName (element.Name)

    let generateName (element: Element) =
        match element with
        | :? Person -> UriSchemes.PersonType + formatNameOfElement element
        | :? SoftwareSystem -> UriSchemes.SoftwareSystemType + formatNameOfElement element
        | :? Container as container ->
            UriSchemes.ContainerType
            + formatNameOfElement container.SoftwareSystem
            + StaticCanonicalNameSeperator
            + formatNameOfElement container
        | :? Component as c ->
            UriSchemes.ComponentType
            + formatNameOfElement c.Container.SoftwareSystem
            + StaticCanonicalNameSeperator
            + formatNameOfElement c.Container
            + StaticCanonicalNameSeperator
            + formatNameOfElement c
        | :? DeploymentNode -> UriSchemes.DeploymentNodeType + formatNameOfElement element
        | :? InfrastructureNode -> UriSchemes.InfrastructureNodeType + formatNameOfElement element
        | :? ContainerInstance -> UriSchemes.ContainerInstanceType + formatNameOfElement element
        | :? SoftwareSystemInstance -> UriSchemes.SoftwareSystemInstanceType + formatNameOfElement element
        | _ -> UriSchemes.CustomElementType + formatNameOfElement element

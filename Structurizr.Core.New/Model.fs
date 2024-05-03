namespace Structurizr

type CodeElementRole =
    | Primary
    | Supporting

type CodeElements =
    { Role: CodeElementRole
      Name: string
      Type: string
      mutable Description: string
      mutable Language: string
      mutable Category: string
      mutable Visibility: string
      mutable Size: int }

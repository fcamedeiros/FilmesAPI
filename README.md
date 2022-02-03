<img src="https://img.shields.io/badge/releasedate-january-orange"/> <img src="https://img.shields.io/badge/status-finalizado-orange"/>

![RoloFilmes](https://user-images.githubusercontent.com/35452578/152268774-aa5f273f-9684-4179-bfe5-d1970404904e.jpg) 

# FilmesAPI
API desenvolvida no curso "API Rest com .Net 5" da Alura cuja persistência de dados ocorre no MySQL e permite o cadastro, busca, alteração e deleção de Filmes. 

## Cadastro
Adiciona um filme no Banco de Dados

### Request
```
POST /Filme
```

### Request Body:
```
{ 
  "titulo" : "string", 
  "genero" : "string", 
  "diretor" : "string", 
  "duracao" : int 
}
```

### Response Body:
```
{
  "id": int,
  "titulo": "string",
  "diretor": "string",
  "genero": "string",
  "duracao": int
}
```

### Status Code:
```
201: Created
400: Bad Request
```

## Busca
Recupera a lista de filmes presentes no Banco de Dados

### Request
```
GET /Filme
```

### Response Body:
```
[
  {
    "id": int,
    "titulo": "string",
    "diretor": "string",
    "genero": "string",
    "duracao": int
  }
]
```

### Status Code:
```
200: Ok
```

## Busca pelo Id
Recupera um filme pelo seu identificador

### Request
```
GET /Filme/{id}
```

### Response Body:
```
{
  "titulo": "string",
  "diretor": "string",
  "genero": "string",
  "duracao": int,
  "horadaconsulta": DateTime
}
```

### Status Code:
```
200: Ok
404: Not Found
```

## Atualização
Atualiza os dados de um filme cadastrado

### Request
```
PUT /Filme/{id}
```

### Request Body:
```
{
  "titulo": "string",
  "diretor": "string",
  "genero": "string",
  "duracao": int
}
```

### Response Body:
```
```

### Status Code:
```
204: No Content
404: Not Found
```

## Deleção
Elimina um filme cadastrado

### Request
```
DELETE /Filme/{id}
```

### Response Body:
```
```

### Status Code:
```
204: No Content
404: Not Found
```

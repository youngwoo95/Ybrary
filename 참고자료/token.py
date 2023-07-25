# https://kauth.kakao.com/oauth/authorize?client_id={REST_API_KEY}&redirect_uri={REDIRECT_URI}&response_type=code


import requests

url = 'https://kauth.kakao.com/oauth/token'
rest_api_key = '자신의 REST API 키'
redirect_uri = 'https://example.com/oauth'
authorize_code = '-7sSp7Xxqw2QAew7-rctWJtZT4ycERTzQM_nylg8bX0OxFcgGegkA9jaVvPLEVOX_FrkxQo9dRoAAAF2qFCIsA'

data = {
    'grant_type':'authorization_code',
    'client_id':rest_api_key,
    'redirect_uri':redirect_uri,
    'code': authorize_code,
    }

response = requests.post(url, data=data)
tokens = response.json()
print(tokens)

# json 저장
import json
#1.
with open(r"C:\Users\user\Desktop\PythonWorkspace\kakao_test\kakao_code.json","w") as fp:
    json.dump(tokens, fp)

#2.
with open("kakao_code.json","w") as fp:
    json.dump(tokens, fp)
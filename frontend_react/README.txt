docker build -t front .
docker run -v ${PWD}:/app -v /app/node_modules -p 3001:3000 --rm front

docker build -t back .
docker run -p 5002:5000 back

http://localhost:3001/


 
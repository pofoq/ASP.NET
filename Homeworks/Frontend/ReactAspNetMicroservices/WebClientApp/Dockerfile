FROM node:22.12-alpine
#WORKDIR /src
WORKDIR /app
COPY package.json ./
RUN npm install
RUN npm install -g dotenv-cli
COPY . .
#WORKDIR "/src/WebClientApp"
# RUN npm install
# RUN npm install -g dotenv-cli
#RUN npm run build-docker
#WORKDIR "/src/WebClientApp/ClientApp"
#EXPOSE 5272
CMD ["npm", "run", "docker"]
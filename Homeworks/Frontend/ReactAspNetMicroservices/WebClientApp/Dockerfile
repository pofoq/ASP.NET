FROM node:22.12-alpine
WORKDIR /src
COPY . .
WORKDIR "/src/WebClientApp"
RUN npm install
RUN npm install -g dotenv-cli
WORKDIR "/src/WebClientApp/ClientApp"
EXPOSE 5272
CMD ["npm", "run", "preview"]
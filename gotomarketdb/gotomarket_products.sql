-- MySQL dump 10.13  Distrib 8.0.19, for Win64 (x86_64)
--
-- Host: localhost    Database: gotomarket
-- ------------------------------------------------------
-- Server version	8.0.19

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `products`
--

DROP TABLE IF EXISTS `products`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `products` (
  `product_id` int NOT NULL AUTO_INCREMENT,
  `product_name` varchar(240) DEFAULT NULL,
  `product_url` varchar(380) DEFAULT NULL,
  `product_description` varchar(600) DEFAULT NULL,
  `product_quantity` int DEFAULT NULL,
  `product_price` int DEFAULT NULL,
  `product_owner_id` int DEFAULT NULL,
  PRIMARY KEY (`product_id`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `products`
--

LOCK TABLES `products` WRITE;
/*!40000 ALTER TABLE `products` DISABLE KEYS */;
INSERT INTO `products` VALUES (1,'Calculadora pré cambriano','https://3.bp.blogspot.com/-ussGLt-BXlM/UBBUxbKQ0SI/AAAAAAAAJmc/V23KvnZ0H9E/s1600/M%C3%A1quina+Facit.JPG','Máquina manual de calcular, que na época em que foi usada, à volta de 1950, era o máximo.',1,25785,1),(2,'Sanduicheira da vovó','https://http2.mlstatic.com/sanduicheira-n2-po-de-forma-lenha-ferro-fundido-bauru-mixto-D_NQ_NP_950311-MLB20521786091_122015-F.jpg','Sanduicheira N2 Pão De Forma Lenha Ferro Fundido',12,3780,1),(3,'Fita com 12 musicas','https://transformese.com.br/wp-content/uploads/2018/08/coisas-antigas3.jpg','Ipod ou Spotify? Que isso! Para escutar aquela música que você tanto gostava era preciso ligar na rádio e pedir. Depois era só gravar em uma fita e torcer para ela não acabar antes da música.',3,2575,1),(4,'Console Nintendo 64','https://br.betterdeals.com/var/excite/storage/images/betterdeals-br/sucesso-nos-negocios/10-coisas-antigas-que-agora-valem-uma-fortuna/for7/12704-1-esl-ES/for7_gallery_image_mobile.jpg','Considerada inovadora na época de seu lançamento, o console era dotado de um processador gráfico projetado pela Silicon Graphics. A Nintendo 64 também contava com um processador de áudio que permitia o uso teórico de até 100 canais de áudio PCM (o que por motivos práticos nunca foi utilizado, já consumiria todos os recursos da CPU).',2,47852,1),(5,'Baleiro de vidro','https://img.ibxk.com.br/2016/04/04/04194026699229.jpg?w=1040','Baleiro de vidro MINI para para uso pessoal como peça de decoração devido seu estilo conservador. Com visual retrô e beleza rara este produto atende a todos os tipos de consumidores ávidos por produtos diferenciados e ao mesmo imunes ao tempo.',25,38522,1),(6,'Pergaminho de feitiço','https://i.ytimg.com/vi/T9bQtzD-OTY/maxresdefault.jpg','Feitiços diversos: Bola de Fogo, Calcinar, Chamas da Fênix, Cone de Frio, Explosão Arcana, Golpe Flamejante, Ignimpacto, Impacto Arcano, Impacto de Fogo, Nova Congelante, Nova de Gelo, Onda de Impacto, Raio de Gelo, Salva Arcana, Sopro do Dragão, Supernova, Tempestade de Éter',999,87452,1),(7,'Carro de corrida','https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcQqhI91XktEWDFVSh1zHMdVb0B-1GR5uItIvJ48NtvraAUuvnKb&usqp=CAU','Que o carro de competição é feito para andar em alta velocidade todo mundo já sabe. Mas quais são as principais diferenças quando o comparamos a um veículo',58,4785863,1),(8,'Tamagotchi Bichinho virtual','https://eutedigo.files.wordpress.com/2010/06/tamagoshi.jpg','O Tamagotchi Connection V3 foi lançado em 2005 no Japão e só agora está se espalhando pela Europa. É o novo \"Tamagotchi Connection\", que, além do sensor infravermelho e de jogos e funções adicionais àquelas conhecidas, tem interação com o computador, em um site \"Tamagotchi Town\", onde pode-se adquirir produtos virtuais através dos pontos ganhos em jogos. Não paga nada para entrar e se divertir. Nem para adquirir os produtos virtuais. Estes são armazenados em seu Tamagochi V2',57,15254,1),(9,'Televisão de tubo','https://i.pinimg.com/236x/31/27/4d/31274dc2c57275f66ca714020494fe93--colorado-television.jpg','Televisão em bom estado, deve ter pelo menos 1000 anos de idade',2,15475,1),(10,'Nokia 3320 o Celular indestrutível','https://img.buzzfeed.com/buzzfeed-static/static/2015-01/22/7/campaign_images/webdr01/25-coisas-que-so-quem-foi-adolescente-nos-anos-20-2-8237-1421928354-0_dblbig.jpg','Que cai e se divide em 23198738917 pedaços, mas você remontava e ficava tudo certo.',25,15247,1),(11,'Computador Apple Macintosh','https://img.olhardigital.com.br/uploads/acervo_imagens/2020/01/r16x9/20200124035323_1200_675_-_apple_macintosh.jpg','A disponibilidade de software é algo crítico para o sucesso de qualquer no sistema computacional, e a Apple está contando com suporte amplo, visto que a máquina não usa programas escritos para MS-DOS ou qualquer outro sistema operacional padrão. Sua inabilidade em rodar o MS-DOS pode ser motivo para sua salvação ou sua derrocada.',25,154723,1);
/*!40000 ALTER TABLE `products` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-04-19 22:55:14

using System;
using System.Collections.Generic;
					
public class Program
{		
	public class Node
	{
		public int x;
		public int y;
		public int d = int.MaxValue;
		public int risk;
		public bool isVisited = false;
	}
	
	public static void Main()
	{
		var readings = input.Split(new string[] { "\r\n" }, StringSplitOptions.None);
    var matrix = new Dictionary<Tuple<int, int>, Node> ();
		
		int i=0;
		int j = 0;
		foreach (string reading in readings) 
		{	
			j = 0;
			foreach (char c in reading)
			{
				matrix[new Tuple<int, int>(i,j)] = new Node() { x=i, y=j, risk= (c - '0') };
				j++;
			}
			i++;
		}
			
		for (var x = 0; x < i; x++)
    {
      for (var y = 0; y < j ; y++)
      {
			  for (var k = 0; k < 5; k++)
        {
          for (var l = 0; l < 5; l++)
          {
            var r= (matrix[new Tuple<int, int>(x,y)].risk + k + l) % 9;
            matrix[new Tuple<int, int>(x + (k * i),y + (l * j))] =
              new Node()
              { 
                x=x + (k * i), 
                y=y + (l * j), 
                risk= r == 0 ? 9 : r
               };
          }
			  }
		  }
		}	
		
    Console.WriteLine(dijkstra(matrix, matrix[new Tuple<int, int>(i*5-1,j*5-1)]));
	}
	
	public static List<Node> getNeighbors(Dictionary<Tuple<int, int>, Node> matrix, Node node)
	{
		List<Tuple<int, int>> coords = new List<Tuple<int, int>>();
			coords.Add(new Tuple<int, int>(node.x - 1, node.y));
			coords.Add(new Tuple<int, int>(node.x + 1, node.y));
			coords.Add(new Tuple<int, int>(node.x, node.y - 1));
			coords.Add(new Tuple<int, int>(node.x , node.y + 1));

		List<Node> neighbors = new List<Node>();
		foreach (Tuple<int, int> coord in coords)
		{
			if (matrix.ContainsKey(coord) && !matrix[coord].isVisited)
			{
				neighbors.Add(matrix[coord]);
			}
		}

		return neighbors;
	}

	public static int dijkstra(Dictionary<Tuple<int, int>, Node> matrix, Node target)
	{
		var pq = new PriorityQueue<Node, int>();
		matrix[new Tuple<int, int>(0,0)].d = 0;
		pq.Enqueue(matrix[new Tuple<int, int>(0,0)], 0);
		while (pq.Count > 0)
		{
			var current = pq.Dequeue();
			if (current.isVisited)
			{
				continue;
			}

			current.isVisited = true;
			if (current == target)
			{
				return target.d;
			}

			foreach (var neighbor in getNeighbors(matrix, current))
			{
				var d = current.d + neighbor.risk;
				if (d < neighbor.d)
				{
					neighbor.d = d;
				}

				if (neighbor.d != int.MaxValue)
				{
					pq.Enqueue(neighbor, neighbor.d);
				}
			}
		}
		
		return target.d;
	}

	private static string input = "6851182918317729984894479998919639588287499951229786985839869531985173849166964176451789434892199898\r\n9426994946481789516799194682986158574783332188959768397416981269349655657969713682881596193639995681\r\n3796886996869882629998132915973989548786867985998963691489853939899277919988858417991899981198719977\r\n9248185139261798695718986776781989149442673212774599795188279468121787972899969696979856585911949398\r\n6299473779566125911813915682136997199718287928169899397951248974185914193847568951998753279193952849\r\n8148286974115181837394769599139891971978995999535739268969879319467496912998861171928998691659198989\r\n7714687982854699756819437711488839929337718978941199979812279537259321914799597345927229986211994549\r\n1859191762117353799861888195973613898594811595799719427974391939471929349466985865972994437884976918\r\n4789924996582993992899958998398993587621899599782949299194867972848998592987992641836281142799987191\r\n9685322981798759174989138791499887198763891994992689973776397683579958996897917454769885649448846998\r\n6789191274213349898637897949987691642999121985912278669499497294631978879989687988772597899489398853\r\n8899541187936687986764981174139122881959961816983885493199685939951265698122877778946175159918528939\r\n9952699986439995635899891246126799752986783919995866921811257898893149769954463369478989997852998513\r\n9931425891581899192381949272615788327478998239344791911714828896265671432569198189774762995997816999\r\n8581618784927336497999229995697796195918393877818976787576616927699141958127928917996839499769899276\r\n8369858669942937955912211816442699772683941894396427761767385991988919159299218913385817898299451225\r\n6599864914998939412789949497399559686786199654269695968467612419638975799587182839689615354288517687\r\n4324765578179939112987917815945377869195454495959997291949517521699691991554697624199589939789426676\r\n8998943917666297991734661946185856692979675845962856849349289995835969527961564598586189299197239649\r\n2474349998759125929824899596169699498194929969789495971989693353319989798589959994997191896775279666\r\n9397823311992847298999315312637987993188796995292697771188653763819292898624997515579394598123986699\r\n2999757939894996746879469973889874978918536847939782945591488939679598979779585959621881889632813415\r\n3786879979379639997228893154199891799657145859599524224228186163438961996693568885878772218711991948\r\n6357119476898367292134799994558999999959123579815889388789382591263761963299898988162997119173898949\r\n3499971911939119191979976923829738974229559772757989872536949884296992794587989427754799689998947769\r\n7319799654652819812812891758592372613871898598499998998769988491199991938858991878959745381157531992\r\n1468684961945168589969992498649126855459472584987975891483519539678195959954998486675329191189898981\r\n5999796535732847747899499629559999481989991291183338213553138881392987929751589694818513519186515989\r\n8969971877279154679687599942839999789819924199219972613989945683512875795799895813819961923866923969\r\n7661989481759992932237691998849721793391539266789486647194998941891234931877977977291988998583745959\r\n7581858699779845989999894928667969596789187889414876715696938619495386625719891737397925889147875514\r\n7939582575855863146589222872971958448862199919156447969996578964676999478369392994395941769419715726\r\n7664919588599891289517773626649579918479785644186954919517715835999961894979829998196877229313779119\r\n9789939779919686938527689899911589971279559121991792659929991899988138467398979998119486996973985156\r\n1987113452341888331415788983939823974158899719369158953599328364987895258517579998193927999942926739\r\n4968168491589593364854994479548794995979997169937913916259791732978999679787499897141429969268954257\r\n2846767823761639989966699865459895813415497745932517967796994194889193889361771837818891946316824181\r\n7419953896616283991529356659738189899382679976716488911915929762836929928489468999824399891189396596\r\n5952664821957739692491929127834595859858331611949787357394798996537991479836188819992989786289969399\r\n1875298894394183776949938912979573795149279972888168285819492911812997337919989696879199478973129985\r\n5919286823859696987961954614228358927895892883936514998729698954459791996176462566948885569496951888\r\n8198742852798283579147798488755458898399659854999332299918738949995991969769999951928783929327999171\r\n9356681651112169821995754898943385719988988159815719149883958216777218975771961399992179627838993749\r\n9571678692979785159914996299396819198518738829982883267189677891687969791655296999744818979781699451\r\n4499977822999798831749658798996911398289176643292258219953597143758461199752382581496999738132666972\r\n9371498489873252352913928911896998598525174889888961698129512999956967836792982999299998439489166519\r\n4363251581111888995249439374596968896688369878747656498596794989464319829991922479788173765678766788\r\n2149531197725793856199668589529279498739416981259391319742193112799977998589916896736999211478384818\r\n6652741812929838829999115348994923982959168836989491996592899776771846988482819696478299997597368387\r\n4255583648819672318175149619998988681895817968598241979393478469969938159217895591146981673999473867\r\n4964555898411593799435321739362869694829778589898553641198115978192569798997991195198219994889942184\r\n9797366423999199172399876696993339889797973193816318914986338494449193894889268661898912981918519764\r\n6687998138292477915197983479277646898952986899794571647684979994699999899996393165938937915729788661\r\n5592847856869753492492988981958829593838157925698792597975879647828769919877219918928989182175476897\r\n8836169198218249896917891911584981355957979918799561597841964324997517581868875971228445214896956594\r\n9991979957665149888945894282198999633228697249992299394919785958996859286299898899826491976111378973\r\n8848142494911863639727694919999799681883967728699792269971997284185487197797785915559194647997869275\r\n7779759189379664999139782196969999463628798838258386616919985751671579842779877794976116569578825591\r\n6759492767112759386944996961961199796599149618819367999459973299889229748688186194846439389594989398\r\n9478522495191693824889482998593861917975499679652969194928977177298698588548892995776988755536949638\r\n2879488429758945861481941459959489291581529327199976734964826343186951997124229199439599789499381947\r\n9151999467195176382792787942529393148979898385319488971788696876995382432981616171947541994599784815\r\n9422899387497981899948996839296997955966599469284618798836617528898869693178818849992862393169691499\r\n3518359996372825883819125785878945215415985684479731169786945848979998959879287967949991364229895176\r\n8976542697288796999257999123221978979998993991724599398569918592973729173898896524714495376969849988\r\n8481395559655988985348879919869898925158361718297615446995721768592296998993331259749599564939998425\r\n7927133913879753889999999849936931818946496994884618913769899788998278717672924799738991955934679754\r\n7699577192967981896479118595952398684291929899991882868845894217211129138513385871694897411152572986\r\n9188998494989968854898371859371587419885768992189979865782478339813897498999329756549179599938818766\r\n9521753599829529719894566318278177879536194823136972369932987791734696899629168989926724859848578771\r\n5551889549448389591869749924679853719451949199598259995443847415337788294519337599819858357135158969\r\n7886393199129989719728316889859919596477729586982989933684389188469986916793178154679354724997978633\r\n9574965391199192981776471866138979925783199887871999639579151787959787986988925838982865489516921196\r\n3927797795488688693698845776289481997518191875929418751151995942699998749969776184299873985282792798\r\n9791559589867397896887412749658968449794651489979158963681479687148898199872939926788748841584889944\r\n5298496949878243647993929791757821993433319291398398984959365589597369893998489597335214676888568151\r\n4992986694879568239987681454396787984419592177669488577398821999236959943476185938293298929999691399\r\n7716811887965378991995647889458718917793892996471748846952649999915673968782252941673739691634491177\r\n3633766499994828892892398927719985744597875769174939892535589929837872989116313627768291599829479799\r\n9827698893491749981968648969283729997499897957413829241748399418793319183931281544259179926519539784\r\n5485613626795937686752924885647181816699936695496996619919897887995593964748977695826489175457928711\r\n8758592799529969633277938996489979686934788817756997869936958149649599491881641998481939955996939599\r\n7978479148937288659399182481174686939422862837694916899697299885375945865142389214689596229652185995\r\n1994663916588999417984895813968577357718789291129992993986921983972374167718984777911379615718952856\r\n8167148183785798577981975199849898879952959145788668868895228269442866271144898849192759218789396797\r\n1949781172329888625969136645967199561289712385582378579599119918929787938572139889725453891691963129\r\n9947178739249111493182923893511575582799998593964983133969459696693991798885993271629469499146876976\r\n9772972829559895899854497885948559996164996778838938289361994913976481619178529958211969726729538135\r\n8927428538918682496914684982756792873489511912321968398812989748695991579992269199467887892982259779\r\n2717218517917675896467119592763877315641496467478259218982588979597999878956958782928839691397643476\r\n8878998995379374928252616995177747994378369327465533881284867384792667719488999812139487971565957894\r\n9768786899684874839228498724461971799469899798671499289819194996996577858899886942968565187998919698\r\n8925519488828789299528988579885957558829879851119599829746182181117497663958391826259185277971643493\r\n7965716992984766446656439596378997979363981699398999919985811839662782937937946281177857997227269847\r\n1559379255299972668933386171592188218898432689787739638786199657415499966284812959999289193169124995\r\n7899899443897639915673626768648226882499987556984997981538887885979994649297111149491991818456198868\r\n5979961891291523299165957518168425311537399524361897896181687192954231889954771797459935798619599423\r\n2121416749725397396399792525295616969118499787997149336296239918996723985978919425198144297736819197\r\n7868796992696828855862952279981147679986829877138887191789385398989849196567297576723547696881529227\r\n8883726744936598689747689939932818828998719994999581122656889578249517477297783467688719959489399394";
}